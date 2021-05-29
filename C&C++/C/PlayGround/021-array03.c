#include <stdio.h>

void main()
{
    int a[3][4] = {{60, 18, 6, 83}, {23, 95, 42, 18}, {2, 80, 65, 36}};
    int x = 0, y = 0, max = a[0][0];

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            printf("%d\t", a[i][j]);
            if (j == 3)
            {
                printf("\n");
            }
        }
    }

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (a[i][j] > max)
            {
                max = a[i][j];
                x = i;
                y = j;
            }
        }
    }

    printf("max number is %d at (%d, %d)\n", max, x, y);
}