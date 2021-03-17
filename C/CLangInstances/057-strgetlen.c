#include <stdio.h>

/*
计算字符串长度
*/

int main()
{
    char s[1000], i;

    printf("输入字符串: ");
    scanf("%s", s);

    for (i = 0; s[i] != '\0'; ++i)
        ;

    printf("字符串长度: %d", i);

    return 0;
}