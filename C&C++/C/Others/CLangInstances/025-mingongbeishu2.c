#include <stdio.h>

int main()
{
    int a, b;
    printf("输入两个正整数，以空格分隔: ");
    scanf("%d %d", &a, &b);

    int mymingx(int a, int b);
    printf("%d 和 %d 的最小公倍数是 %d\n", a, b, mymingx(a, b));

    return 0;
}

int mymingx(int a, int b)
{
    if (a < b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    for (int i = 1; i <= b; i++)
    {
        if (a * i % b == 0)
        {
            return a * i;
        }
    }
}