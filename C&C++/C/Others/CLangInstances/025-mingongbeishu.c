#include <stdio.h>

/*
用户输入两个数，求这两个数的最小公倍数。
*/

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
    int result = 1;

    int mymaxgcd(int a, int b);

    return a * b / mymaxgcd(a, b);
}

int mymaxgcd(int a, int b)
{
    if (a < b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    int c = a % b;
    if (c == 0)
        return b;
    else
        mymaxgcd(b, c);
}