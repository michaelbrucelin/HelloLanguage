#include <stdio.h>

void main()
{
    int a[2][3] = {{1, 2, 3}, {4, 5, 6}};
    int b[3][2];

    printf("array a is:\n");
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            printf("%d\t", a[i][j]);
            if (j == 2)
            {
                printf("\n");
            }
        }
    }

    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            b[j][i] = a[i][j];
        }
    }

    printf("array b is:\n");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 2; j++)
        {
            printf("%d\t", b[i][j]);
            if (j == 1)
            {
                printf("\n");
            }
        }
    }

    printf("\n");
}