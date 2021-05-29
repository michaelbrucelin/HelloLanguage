#include <stdio.h>

/*
使用 scanf() 来接收输入， printf() 与 %d 格式化输出整数。
*/

int main()
{
    int firstNumber, secondNumber, sumOfTwoNumbers;

    printf("输入两个数(以空格分割): ");

    // 通过 scanf() 函数接收用户输入的两个整数
    scanf("%d %d", &firstNumber, &secondNumber);

    // 两个数字相加
    sumOfTwoNumbers = firstNumber + secondNumber;

    // 输出结果
    printf("%d + %d = %d", firstNumber, secondNumber, sumOfTwoNumbers);

    return 0;
}