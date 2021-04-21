#include <stdio.h>
#include <math.h>

/*
假如a*b=c（a、b、c都是整数)，那么我们称a和b就是c的因数。
*/

int main()
{
    int number, i;

    printf("输入一个整数: ");
    scanf("%d", &number);

    printf("%d 的因数有: ", number);
    for (i = 1; i <= sqrt(number); ++i)
    {
        if (number % i == 0)
        {
            printf("%d %d ", i, number / i);
        }
    }
    printf("\n");

    return 0;
}