#include <stdio.h>

/*
自然数是指表示物体个数的数，即由0开始，0，1，2，3，4，……一个接一个，组成一个无穷的集体，即指非负整数。
*/

int main()
{
    int n, i, sum = 0;

    printf("输入一个正整数: ");
    scanf("%d", &n);

    for (i = 1; i <= n; ++i)
    {
        sum += i; // sum = sum+i;
    }

    printf("Sum = %d", sum);

    return 0;
}