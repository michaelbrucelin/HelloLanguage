#include <stdio.h>

int main()
{
    char *strs[] = {"mlin.com", "www.mlin.com", "home.mlin.com", "mlin.cn", "hello world", "hi mlin", "thank you"};
    char **p;

    int len = sizeof(strs) / sizeof(strs[0]);
    for (int i = 0; i < len; i++)
    {
        p = strs + i;
        printf("%s\n", *p);
    }
}