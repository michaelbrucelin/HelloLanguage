#include <stdio.h>

/*
字符串复制
*/

int main()
{
    char s1[100], s2[100], i;

    printf("字符串 s1: ");
    scanf("%s", s1);

    for (i = 0; s1[i] != '\0'; ++i)
    {
        s2[i] = s1[i];
    }

    s2[i] = '\0';
    printf("字符串 s2: %s", s2);

    return 0;
}