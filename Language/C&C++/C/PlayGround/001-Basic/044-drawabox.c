#include <stdio.h>

int main(void)
{
    int len;
    printf("input a number\n");
    scanf("%d", &len);

    int i, j;
    for (i = 0; i < len; i++)
    {
        if (i == 0 || i == len - 1)
        {
            for (j = 0; j < len; j++)
            {
                printf("*");
            }
            printf("\n");
        }
        else
        {
            printf("*");
            for (j = 1; j < len - 1; j++)
            {
                printf(" ");
            }
            printf("*");
            printf("\n");
        }
    }

    return (0);
}