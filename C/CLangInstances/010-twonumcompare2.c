#include <stdio.h>

int main()
{
    int a, b, c;

    a = 11;
    b = 22;
    c = 33;

    if (a > b && a > c)
        printf("%d 最大", a);
    else if (b > a && b > c)
        printf("%d 最大", b);
    else if (c > a && c > b)
        printf("%d 最大", c);
    else
        printf("有两个或三个数值相等");

    return 0;
}