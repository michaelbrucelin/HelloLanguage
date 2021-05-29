#include <stdio.h>

/*
两数相除，如果有余数，输出余数。
*/

int main()
{
    int dividend, divisor, quotient, remainder;

    printf("输入被除数: ");
    scanf("%d", &dividend);

    printf("输入除数: ");
    scanf("%d", &divisor);

    // 计算商
    quotient = dividend / divisor;

    // 计算余数
    remainder = dividend % divisor;

    printf("商 = %d\n", quotient);
    printf("余数 = %d\n", remainder);

    return 0;
}