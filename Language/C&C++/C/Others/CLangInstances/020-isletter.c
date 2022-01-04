#include <stdio.h>

/*
用户输入一个字符，判断该字符是否为一个字母。
*/

int main()
{
    char c;
    printf("输入一个字符: ");
    scanf("%c", &c);

    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
        printf("%c 是字母", c);
    else
        printf("%c 不是字母", c);

    return 0;
}