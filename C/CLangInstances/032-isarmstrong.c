#include <stdio.h>
#include <math.h>

/*
Armstrong数，就是n位数的各位数的n次方之和等于该数，如：
153=1^3+5^3+3^3
1634=1^4+6^4+3^4+4^4
*/

int main()
{
    int n, len = 0, m = 0;

    printf("输入一个正整数: ");
    scanf("%d", &n);

    int n0 = n;

    while (n != 0)
    {
        n /= 10;
        len++;
    }

    n = n0;
    while (n != 0)
    {
        m += pow((n % 10), len);
        n /= 10;
    }

    if (m == n0)
        printf("%d is armstrong.\n", n0);
    else
        printf("%d is not armstrong.\n", n0);

    return 0;
}