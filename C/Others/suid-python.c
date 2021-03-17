/* suid-python version 0.95
 *   by Steven Elliott <selliott4@austin.rr.com>
 *
 * A program to securely run Python scripts with the setuid bits set on the
 * script applied to the resulting Python process as if the Python script was
 * an executable.  This utility could probably be easily adapted to other
 * scripting languages.
 *
 * Install this program by building it with
 *   gcc -o suid-python suid-python.c
 * then copy it to a secure directory
 *   cp suid-python /usr/local/bin
 * and then set the ownership to root setuid bit
 *   chown root.root suid-python
 *   chmod 755 suid-python
 *   chmod u+s suid-python
 *
 * Try it by creating a secure Python script that starts with
 *   #!/usr/bin/env suid-python
 * that is to run as a user other than the invoking user.  Set that user and
 * corresponding setuid bits, and then run it.
 *
 * This program is subject to the same open source license as Python:
 *   http://www.python.org/2.4.2/license.html
 */

#include <errno.h>
#include <libgen.h>
#include <pwd.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>

/* Defines */

/* Flags.  There are to be used with "#if", not "#ifdef".  These are all off
 * since there are security problems with each one.
 */
#define ISEC_ALLOWED 0     /* Isecure directories. */
#define STICKY_ALLOWED 0   /* Consider sticky bits, such as /tmp */
#define SWITCHES_ALLOWED 0 /* Python switches, such as -i */

#define NOBODY "nobody"
#define PYTHON "python"
#define SAFE_PATH "PATH=/usr/local/sbin:/usr/local/bin:/sbin:/bin:" \
                  "/usr/sbin:/usr/bin:/usr/X11R6/bin"

/* Globals */

/* Harmful environment variables on Linux.  Other OSs may have other 
 * variables.
 */
static char *bad_prefixes[] = {"IFS", "LD_", "PATH", "PYTHON", NULL};

/* Directories that are likely to be trusted (directories that are likely to
 * be local and that don't have the "nosuid" mount option set).
 */
#if !ISEC_ALLOWED
static char *trusted_dirs[] = {"/bin/", "/boot/", "/etc/", "/lib/", "/opt/",
                               "/root/", "/sbin/", "/usr/", NULL};
#endif

static gid_t script_gid;
static int script_sgid_set;
static int script_suid_set;
static uid_t script_uid;
struct stat script_stat;

void usage(char *name)
{
    fprintf(stderr, "Usage: %s suid-script [arg1 [arg2 ..]]\n",
            basename(name));
}

/* Wrapper functions that abort when they fail. */

char *
getcwd_abort(char *buf, size_t size)
{
    char *cwd;

    cwd = getcwd(buf, size);
    if (!cwd)
    {
        fprintf(stderr, "Could not get the CWD of %s.  errno=%d\n",
                buf, errno);
        exit(1);
    }

    return cwd;
}

int lstat_abort(const char *file_name, struct stat *buf)
{
    if (lstat(file_name, buf) == -1)
    {
        fprintf(stderr, "Could not lstat %s.  errno=%d\n", file_name, errno);
        exit(1);
    }

    return 0;
}

void *
malloc_abort(size_t size)
{
    void *buf;

    buf = malloc(size);
    if (!buf)
    {
        fprintf(stderr, "Could not allocate %d bytes.  errno=%d\n",
                size, errno);
        exit(1);
    }

    return buf;
}

/* Like seteuid() and setegid(), but abort if we can't set it. */

void setegid_abort(uid_t egid)
{
    if (setegid(egid) == -1)
    {
        fprintf(stderr, "Could not set the EGID to %d.  errno=%d\n",
                egid, errno);
        exit(1);
    }
}

void seteuid_abort(uid_t euid)
{
    if (seteuid(euid) == -1)
    {
        fprintf(stderr, "Could not set the EUID to %d.  errno=%d\n",
                euid, errno);
        exit(1);
    }
}

char *
strdup_abort(char *old_str)
{
    char *new_str;

    if (!old_str)
    {
        fprintf(stderr, "Null string passed to strdup_abort()\n");
        exit(1);
    }

    new_str = strdup(old_str);
    if (!new_str)
    {
        fprintf(stderr, "Unable to duplicate %s\n", old_str);
        exit(1);
    }

    return new_str;
}

int remove_env_prefix(char **envp, char *prefix)
{
    char **envp_read;
    char **envp_write;
    int prefix_len = strlen(prefix);
    int removed_count = 0;

    envp_write = envp;
    for (envp_read = envp; *envp_read; envp_read++)
    {
        if (!strncmp(*envp_read, prefix, prefix_len))
        {
            /* Step past the environment variable that we don't want. */
            removed_count++;
            continue;
        }

        if (envp_read != envp_write)
        {
            *envp_write = *envp_read;
        }

        envp_write++;
    }

    /* Set the remaining slots to NULL. */
    if (envp_write < envp_read)
    {
        memset(envp_write, 0, ((unsigned int)envp_read - (unsigned int)envp_write));
    }

    return removed_count;
}

void put_env(char **envp, char *string)
{
    char **envp_step;

    /* Search for the null at the end. */
    for (envp_step = envp; *envp_step; envp_step++)
        ;

    *(envp_step++) = string;
    *envp_step = 0;
}

/* Determine if a script is secure by walking the directory structure and
 * making sure it is not world writable and that it is not a symlink.  
 * This script sets various global variables that main() depends on.
 */
int script_secure(char *script, int do_abort)
{
    char *fq_script = NULL;
    char *last_slash;
    char *script_cwd;
    int script_uid_set = 0;
    int sticky_bit;

#if !ISEC_ALLOWED
    char **trusted_dir;
#endif

    if (*script == '/')
    {
        fq_script = strdup_abort(script);
    }
    else
    {
        script_cwd = getcwd_abort(NULL, 0); /* Works on non-Linux? */
        fq_script = (char *)malloc_abort(strlen(script_cwd) + 1 +
                                         strlen(script) + 1);
        sprintf(fq_script, "%s/%s", script_cwd, script);
        free(script_cwd);
    }

    if (strstr(fq_script, ".."))
    {
        /* It may not be possible to do anything bad with paths with ".." in
         * them, but there is no good reason to allow it.
         */
        fprintf(stderr, "%s contains '..'\n", fq_script);
        goto script_failed;
    }

    while (1)
    {
        lstat_abort(fq_script, &script_stat);

        /* We may not gain much by checking for symlinks given the other
         * checks, but its reassuring that the script can't be tricked into
         * thinking it has a different dirname or basename than it actually
         * does.
         */
        if (S_ISLNK(script_stat.st_mode))
        {
            fprintf(stderr, "%s is a symlink\n", fq_script);
            goto script_failed;
        }

        if (!script_uid_set)
        {
            script_uid = script_stat.st_uid;
            script_gid = script_stat.st_gid;
            script_suid_set = (S_ISUID & script_stat.st_mode) ? 1 : 0;
            script_sgid_set = (S_ISGID & script_stat.st_mode) ? 1 : 0;
            script_uid_set = 1;

            if ((!script_suid_set) && (!script_sgid_set))
            {
                /* If neither suid bit is set then there is no risk.  Just
                 * run the script.
                 */
                break;
            }

#if !ISEC_ALLOWED
            /* This check is here instead of before the loop since we want to
             * give the ordinary scripts a chance to work (the above check).
             */
            for (trusted_dir = trusted_dirs; *trusted_dir; trusted_dir++)
            {
                if (!strncmp(*trusted_dir, fq_script, strlen(*trusted_dir)))
                {
                    break;
                }
            }

            if (!*trusted_dir)
            {
                fprintf(stderr, "%s is not in a trusted directory\n",
                        fq_script);
                goto script_failed;
            }
#endif
        }

        /* Make sure that a non-root user other than the owner of the script
         * has created a copy of the script in another directory by
         * hard-linking.
         */
        if (script_stat.st_uid && (script_stat.st_uid != script_uid))
        {
            fprintf(stderr, "%s is not owned by either same user as %s or "
                            "root\n",
                    fq_script, script);
            goto script_failed;
        }

        /* Similar to the above, but for groups.  There is only a risk of
         * doing bad things with sgid if it is set.
         */
        if (script_sgid_set && script_stat.st_gid &&
            (script_stat.st_gid != script_gid))
        {
            fprintf(stderr, "%s is not owned by either same group as %s or "
                            "the root group\n",
                    fq_script, script);
            goto script_failed;
        }

#if STICKY_ALLOWED
        sticky_bit = (S_ISVTX & script_stat.st_mode) ? 1 : 0;
#else
        sticky_bit = 0;
#endif

        /* We want to avoid a race condition where someone changes the script
         * between these checks and when python is exec'd by making sure that
         * another script can't be moved in place of the script being checked.
         */
        if ((S_IWOTH & script_stat.st_mode) && !sticky_bit)
        {
            fprintf(stderr, "%s is world writable\n", fq_script);
            goto script_failed;
        }

        /* This makes it harder for non-root users to make setuid scripts
         * on systems that use user private groups (umask of 002), but its
         * a necessary check to make sure things are secure.
         */
        if ((S_IWGRP & script_stat.st_mode) && !sticky_bit)
        {
            fprintf(stderr, "%s is group writable\n", fq_script);
            goto script_failed;
        }

        if (!strcmp(fq_script, "/"))
        {
            /* If we made it to / we are done. */
            break;
        }

        last_slash = strrchr(fq_script, '/');
        if (!last_slash)
        {
            /* This should not happen. */
            fprintf(stderr, "%s does not contain a '/'\n", fq_script);
            goto script_failed;
        }

        /* Remove the last path element. */
        if (last_slash == fq_script)
        {
            /* Treat '/' as a special case.  By previous checks we know there
             * is enough space to write the 0.
             */
            last_slash[1] = 0;
        }
        else
        {
            *last_slash = 0;
        }
    }

    free(fq_script);
    return 1;

script_failed:
    if (fq_script)
    {
        free(fq_script);
    }
    if (do_abort)
    {
        exit(1);
    }
    return 0;
}

int main(int argc, char **argv, char **envp)
{
    char **bad_prefix_ptr;
    char *real_python;
    char **safe_argv;
    char **safe_env;
    char *script;
    int real_python_len;
    int removed_count = 0;
    int script_idx;

    if (argc < 2)
    {
        usage(argv[0]);
        exit(1);
    }

    /* Unset dangerous environment variables. */
    for (bad_prefix_ptr = bad_prefixes; *bad_prefix_ptr; bad_prefix_ptr++)
    {
        removed_count += remove_env_prefix(envp, *bad_prefix_ptr);
    }

    /* Set the path to a known safe value. */
    if (!removed_count)
    {
        fprintf(stderr, "There is no room in envp to set the new path.\n");
        exit(1);
    }
    put_env(envp, SAFE_PATH);

    /* Assume the script is the first non-switch. */
    for (script_idx = 1; script_idx < argc; script_idx++)
    {
        if (*argv[script_idx] == '-')
        {
            /* Reject all switches so that it is not possible to just run
             *     suid-python -i some_script
             * Alternatively the switches can be ignored.
             */
#if !SWITCHES_ALLOWED
            fprintf(stderr, "The command line python switch '%s' is not "
                            "permitted.\n",
                    argv[script_idx]);
            exit(1);
#endif
        }
        else
        {
            break;
        }
    }
    if (script_idx >= argc)
    {
        fprintf(stderr, "Unable to find a script in the arguments "
                        "provided.\n");
        exit(1);
    }
    script = argv[script_idx];

    /* Make sure that the scripts directories are secure and that symlink
     * attacks are not possible.
     */
    script_secure(script, 1);

    /* For each mode where the setuid bit is set set the corresponding id
     * on the file, otherwise revert to the invoking user.  Group is done
     * before user so this script will still have permission to do it.
     */

    if (script_sgid_set)
    {
        setegid_abort(script_gid);
    }
    else
    {
        setegid_abort(getgid());
    }

    if (script_suid_set)
    {
        seteuid_abort(script_uid);
    }
    else
    {
        seteuid_abort(getuid());
    }

    /* Arguments "python suid-script arg1 arg2 ..." for python. */
    safe_argv = &argv[script_idx - 1];
    safe_argv[0] = PYTHON;

    /* Try python in two safe locations and then give up. */
    execve("/usr/local/bin/" PYTHON, safe_argv, envp);
    execve("/usr/bin/" PYTHON, safe_argv, envp);

    fprintf(stderr, "Unable to exec python.  errno=%d\n", errno);

    return 1;
}