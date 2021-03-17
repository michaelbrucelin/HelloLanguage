#include <stdio.h>

/*
使用两层递归来实现，练习递归
*/

int main()
{
    void RecursionV(int n);
    RecursionV(9);

    return 0;
}

void RecursionV(int n)
{
    void RecursionH(int n, int i);

    if (n == 1)
    {
        RecursionH(1, 1);
    }
    else
    {
        RecursionV(n - 1);
        RecursionH(n, n);
    }
}

void RecursionH(int n, int i)
{
    if (i == 1)
    {
        printf("1 * %d = %d\t", n, n);
    }
    else
    {
        RecursionH(n, i - 1);
        printf("%d * %d = %d\t", i, n, i * n);
    }

    if (i == n)
        printf("\n");
}