#include <stdio.h>

/*
用户输入两个数，求这两个数的最大公约数。
*/

int main()
{
    int a, b;
    printf("输入两个正整数，以空格分隔: ");
    scanf("%d %d", &a, &b);

    int mymaxgcd(int a, int b);
    printf("%d 和 %d 的最大公约数是 %d\n", a, b, mymaxgcd(a, b));

    return 0;
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