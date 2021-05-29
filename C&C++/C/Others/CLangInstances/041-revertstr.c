#include <stdio.h>

/*
反转字符串
*/

int main()
{
    char str[1024] = {'\0'};

    printf("输入一个字符串: ");
    scanf("%s", &str);
    printf("%s\n", str);

    //反转字符串
    int len;
    for (len = 0; str[len] != '\0'; len++)
        ;

    char strr[len + 1];
    for (int i = 0; i < len; i++)
    {
        strr[i] = str[len - 1 - i];
    }
    strr[len + 1] = '\0';
    printf("%s\n", strr);

    return 0;
}