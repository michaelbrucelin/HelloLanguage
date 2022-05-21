#include <dirent.h>
#include <errno.h>

static int l_dir(lua_State *L)
{
    DIR *dir;
    struct dirent *entry;
    int i;
    const char *path = luaL_checkstring(L, 1);
    /* open directory */
    dir = opendir(path);
    if (dir == NULL)
    {                                       /* error opening the directory? */
        lua_pushnil(L);                     /* return nil */
        lua_pushstring(L, strerror(errno)); /* and error message */
        return 2;                           /* number of results */
    }
    /* create result table */
    lua_newtable(L);
    i = 1;
    while ((entry = readdir(dir)) != NULL)
    {
        lua_pushnumber(L, i++);           /* push key */
        lua_pushstring(L, entry->d_name); /* push value */
        lua_settable(L, -3);
    }
    closedir(dir);
    return 1; /* table is already on top */
}