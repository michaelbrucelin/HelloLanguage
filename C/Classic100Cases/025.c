/*
题目：求1+2!+3!+...+20!的和。

程序分析：此程序只是把累加变成了累乘。
*/

#include <stdio.h>

int main(void)
{
    int i;
    long double sum, mix;
    sum = 0, mix = 1;
    for (i = 1; i <= 20; i++)
    {
        mix = mix * i;
        sum = sum + mix;
    }
    printf("%Lf\n", sum);

    return (0);
}