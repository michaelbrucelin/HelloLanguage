#include <stdio.h>
#include <ctype.h>

//先来一个简易版的计算器

int main(void)
{
    double number1 = 0.0;
    double number2 = 0.0;
    char operation = 0; // 运算符：+, -, *, /, %
    char reply = 0;

    printf("Enter the calculation\n");
    scanf("%lf %c %lf", &number1, &operation, &number2);

    switch (operation)
    {
    case '+':
        printf("= %lf\n", number1 + number2);
        break;
    case '-':
        printf("= %lf\n", number1 - number2);
        break;
    case '*':
        printf("= %lf\n", number1 * number2);
        break;
    case '/':
        if (number2 == 0) //检查除数是否为0
            printf("\n\n\aDivision by zero error!\n");
        else
            printf("= %lf\n", number1 / number2);
        break;
    case '%': //检查除数是否为0
        if ((long)number2 == 0)
            printf("\n\n\aDivision by zero error!\n");
        else
            printf("= %ld\n", (long)number1 % (long)number2);
        break;
    default: //无效的运算符
        printf("\n\n\aIllegal operation!\n");
        break;
    }

    return 0;
}
