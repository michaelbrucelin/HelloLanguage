/*
题目：一个偶数总能表示为两个素数之和。

程序分析：我去，这是什么题目，要我证明这个问题吗？真不知道怎么证明。那就把一个偶数分解成两个素数吧。
*/

#include <stdio.h>
#include <stdlib.h>

int Isprimer(unsigned int n);

int main(void)
{
    unsigned int n, i;
    do
    {
        printf("请输入一个偶数:\n");
        scanf("%d", &n);
    } while (n % 2 != 0);
    for (i = 1; i < n; i++)
        if (Isprimer(i) && Isprimer(n - i))
            break;
    printf("偶数%d可以分解成%d和%d两个素数的和\n", n, i, n - i);

    return (0);
}

int Isprimer(unsigned int n)
{
    int i;
    if (n < 4)
        return 1;
    else if (n % 2 == 0)
        return 0;
    else
        for (i = 3; i < sqrt(n) + 1; i++)
            if (n % i == 0)
                return 0;

    return 1;
}