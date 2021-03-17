#include <stdio.h>

void main()
{
    int i, a[8] = {1, 2, 3, 4}, b[8];

    printf("array a is:");
    for (i = 0; i < 8; i++)
    {
        printf("%d\t", a[i]);
    }

    printf("\narray b is:");
    for (i = 0; i < 8; i++)
    {
        printf("%d\t", b[i]);
    }

    printf("\n");
}