#include <stdio.h>

void main()
{
    int a[10] = {89, 97, 41, 62, 13, 89, 8, 65, 93};

    for (int i = 0; i < 10; i++)
    {
        printf("%d\t", a[i]);
    }
    printf("\n");

    for (int i = 0; i < 10 - 1; i++)
    {
        for (int j = 0; j < 10 - 1 - i; j++)
        {
            if (a[j] > a[j + 1])
            {
                a[j] += a[j + 1];
                a[j + 1] = a[j] - a[j + 1];
                a[j] -= a[j + 1];
            }
        }
    }

    for (int i = 0; i < 10; i++)
    {
        printf("%d\t", a[i]);
    }

    printf("\n");
}