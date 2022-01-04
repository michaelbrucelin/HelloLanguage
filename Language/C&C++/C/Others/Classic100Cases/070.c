/*
题目：写一个函数，求一个字符串的长度，在 main 函数中输入字符串，并输出其长度。

程序分析：无。
*/

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int len;
    char str[20];
    printf("请输入字符串:\n");
    scanf("%s", str);
    len = length(str);
    printf("字符串有 %d 个字符。", len);

    return (0);
}

int length(char *s)
{
    int i = 0;
    while (*s != '\0')
    {
        i++;
        s++;
    }
    return i;
}