/*
题目：输入一个任意字符串，反向输出

程序分析：使用递归来实现，练习递归
*/

#include <stdio.h>

void reverseString();

int main(void)
{
    printf("please input a string:\n");
    reverseString();

    printf("\n");

    return (0);
}

void reverseString()
{
    char c;
    scanf("%c", &c);
    if (c != '\n')
        reverseString();
    if (c != '\n')
        printf("%c", c);
}