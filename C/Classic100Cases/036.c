/*
题目：求100之内的素数。

程序分析：质数（prime number）又称素数，有无限个。一个大于1的自然数，除了1和它本身外，不能被其他自然数整除。
*/

#include <stdio.h>
#include <math.h>

int main(void)
{
    int i, j, k, n = 0;
    for (i = 2; i <= 100; i++)
    {
        k = (int)sqrt(i);
        for (j = 2; j <= k; j++)
            if (i % j == 0)
                break;
        if (j > k)
        {
            printf("%d ", i);
            n++;
            if (n % 5 == 0)
                printf("\n");
        }
    }

    return (0);
}