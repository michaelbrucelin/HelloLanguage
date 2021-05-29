#include <stdio.h>

int main()
{
    int n, i, sum = 0;

    printf("输入一个正整数: ");
    scanf("%d", &n);

    i = 1;
    while (i <= n)
    {
        sum += i;
        ++i;
    }

    printf("Sum = %d", sum);

    return 0;
}