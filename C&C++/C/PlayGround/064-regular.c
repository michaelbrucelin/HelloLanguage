#include <regex.h>

// 正则表达式示例

regex_t regex;
int reti;
char msgbuf[100];

/* Compile regular expression */
reti = regcomp(&regex, "^a[[:alnum:]]", 0);
if (reti)
{
    fprintf(stderr, "Could not compile regex\n");
    exit(1);
}

/* Execute regular expression */
reti = regexec(&regex, "abc", 0, NULL, 0);
if (!reti)
{
    puts("Match");
}
else if (reti == REG_NOMATCH)
{
    puts("No match");
}
else
{
    regerror(reti, &regex, msgbuf, sizeof(msgbuf));
    fprintf(stderr, "Regex match failed: %s\n", msgbuf);
    exit(1);
}

/* Free memory allocated to the pattern buffer by regcomp() */
regfree(&regex);


/*
https://stackoverflow.com/questions/1085083/regular-expressions-in-c-examples

Regular expressions actually aren't part of ANSI C.
It sounds like you might be talking about the POSIX regular expression library, which comes with most (all?) *nixes.
Here's an example of using POSIX regexes in C (based on this):

Alternatively, you may want to check out PCRE, a library for Perl-compatible regular expressions in C.
The Perl syntax is pretty much that same syntax used in Java, Python, and a number of other languages. The POSIX syntax is the syntax used by grep, sed, vi, etc.
*/

