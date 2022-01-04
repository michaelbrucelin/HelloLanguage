#include <stdio.h>

int main()
{
    double firstNumber, secondNumber, temporaryVariable;

    printf("输入第一个数字: ");
    scanf("%lf", &firstNumber);

    printf("输入第二个数字: ");
    scanf("%lf", &secondNumber);

    // 将第一个数的值赋值给 temporaryVariable
    temporaryVariable = firstNumber;

    // 第二个数的值赋值给 firstNumber
    firstNumber = secondNumber;

    // 将 temporaryVariable 赋值给 secondNumber
    secondNumber = temporaryVariable;

    printf("\n交换后, firstNumber = %.2lf\n", firstNumber);
    printf("交换后, secondNumber = %.2lf", secondNumber);

    return 0;
}