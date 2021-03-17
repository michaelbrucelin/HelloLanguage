#include <stdio.h>
#include <math.h>

void main()
{
    double x, s;
    printf("input number:\n");
    scanf("%lf", &x);
    s = sin(x);
    printf("sin of %lf is %lf\n", x, s);
}

// gcc 01-sin.c -o sin -lm