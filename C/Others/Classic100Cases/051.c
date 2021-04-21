/*
题目：学习使用按位与 &。

程序分析：0&0=0; 0&1=0; 1&0=0; 1&1=1 。
*/

#include <stdio.h>

int main(void)
{
    int a, b;
    a = 077;
    b = a & 3;
    printf("a & b(decimal) 为 %d \n", b);
    b &= 7;
    printf("a & b(decimal) 为 %d \n", b);

    return (0);
}