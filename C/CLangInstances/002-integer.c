#include <stdio.h>

/*
使用 printf() 与 %d 格式化输出整数。
*/

int main()
{
    int number;

    // printf() 输出字符串
    printf("输入一个整数: \n");

    // scanf() 格式化输入
    scanf("%d", &number);

    // printf() 显示格式化输入
    printf("你输入的整数是: %d\n", number);

    return 0;
}