#include <stdio.h>

void main()
{
    int a, b, c, d;
    unsigned u;
    a = 12;
    b = -24;
    u = 10;
    c = a + u;
    d = b + u;
    printf("%d+%d=%d, %d+%d=%d\n", a, u, c, b, u, d);
}