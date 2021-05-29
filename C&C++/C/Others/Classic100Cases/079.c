/*
题目：字符串排序。

程序分析：无。
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void swap(char *str1, char *str2);

int main(void)
{
    char str1[20], str2[20], str3[20];
    printf("请输入3个字符串,每个字符串以回车结束!:\n");
    fgets(str1, (sizeof str1 / sizeof str1[0]), stdin);
    fgets(str2, (sizeof str2 / sizeof str2[0]), stdin);
    fgets(str3, (sizeof str3 / sizeof str3[0]), stdin);
    if (strcmp(str1, str2) > 0)
        swap(str1, str2);
    if (strcmp(str2, str3) > 0)
        swap(str2, str3);
    if (strcmp(str1, str2) > 0)
        swap(str1, str2);
    printf("排序后的结果为：\n");
    printf("%s\n%s\n%s\n", str1, str2, str3);

    return (0);
}

void swap(char *str1, char *str2)
{
    char tem[20];
    strcpy(tem, str1);
    strcpy(str1, str2);
    strcpy(str2, tem);
}