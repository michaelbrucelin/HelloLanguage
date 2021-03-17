#include <stdio.h>

/*
弗洛伊德三角形
*/

#define N 10
int main()
{
    int i, j, l;
    for (i = 1, j = 1; i <= N; i++)
    {
        for (l = 1; l <= i; l++, j++)
            printf("%5d", j);
        printf("\n");
    }

    return 0;
}