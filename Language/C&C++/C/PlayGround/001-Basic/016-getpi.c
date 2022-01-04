#include <stdio.h>

void main()
{
    int level;
    double pi = 0;
    int fuhao = -1;

    printf("input how many times to level\n");
    scanf("%d", &level);

    for (int i = 1; i <= level; i++)
    {
        fuhao *= -1;
        pi += fuhao * 1.0 / (i * 2 - 1);
    }

    printf("pi=%10.8f\n", pi * 4);
}