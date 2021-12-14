#include <stdio.h>

void main()
{
    int mypow(int a, int p);

    int a, p;
    printf("input base\n");
    // a = getchar();
    scanf("%d", &a);
    printf("input power\n");
    // p = getchar();
    scanf("%d", &p);

    printf("%d power %d = %d\n", a, p, mypow(a, p));
}

int mypow(int a, int p)
{
    int r = 1;
    while (p-- > 0)
    {
        r *= a;
    }

    return r;
}