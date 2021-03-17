#include <stdio.h>

#define MAX(a, b) (a > b) ? a : b

int main(void)
{
    int x, y, max;

    printf("input two numbers\n");
    scanf("%d %d", &x, &y);

    printf("the max number is %d.\n", MAX(x, y));

    return (0);
}