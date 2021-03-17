/*
题目：学习使用按位或 |。

程序分析：0|0=0; 0|1=1; 1|0=1; 1|1=1 。
*/

#include <stdio.h>

int main(void)
{
    int a, b;
    a = 077;
    b = a | 3;
    printf("b 的值为 %d \n", b);
    b |= 7;
    printf("b 的值为 %d \n", b);

    return (0);
}