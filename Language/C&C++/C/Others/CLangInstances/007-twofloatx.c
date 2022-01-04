#include <stdio.h>

/*
输入两个浮点数，计算乘积。
*/

int main()
{
    double firstNumber, secondNumber, product;
    printf("输入两个浮点数: ");

    // 用户输入两个浮点数
    scanf("%lf %lf", &firstNumber, &secondNumber);

    // 两个浮点数相乘
    product = firstNumber * secondNumber;

    // 输出结果， %.2lf 保留两个小数点
    printf("结果 = %.2lf", product);

    return 0;
}