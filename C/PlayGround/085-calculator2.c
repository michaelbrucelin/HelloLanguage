#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>
#include <math.h>

/*
进阶的计算器
实现目标：
1、允许使用有符号的整数和小数；
2、允许使用表达式，如2.5+3.7-6/6；
3、使用^表示幂运算；
4、允许使用上一次的运算结果，例如上一次的运算结果为2.5，则=*2+7结果为12；
5、不考虑运算优先级；
实现步骤：
1、读入用户输入的字符串，如果是quit，就退出；
2、检查=运算符
3、分析运算符，从左到右依次运算，直至表达式结束
4、打印结果
*/

#define BUFFER_LEN 256 //运算表达式的长度

int main(void)
{
    char input[BUFFER_LEN]; /* Input expression                  */
    char number_string[30]; /* Stores a number string from input */
    char op = 0;            /* Stores an operator                */

    unsigned int index = 0;         /* Index of the current character in input   */
    unsigned int to = 0;            /* To index for copying input to itself      */
    size_t input_length = 0;        /* Length of the string in input             */
    unsigned int number_length = 0; /* Length of the string in number_string   */
    double result = 0.0;            /* The result of an operation                */
    double number = 0.0;            /* Stores the value of number_string         */

    printf("\nTo use this calculator, enter any expression with or without spaces");
    printf("\nAn expression may include the operators:");
    printf("\n          +, -, *, /, %%, or ^(raise to a power).");
    printf("\nUse = at the beginning of a line to operate on ");
    printf("\nthe result of the previous calculation.");
    printf("\nUse quit by itself to stop the calculator.\n\n");

    /* The main calculator loop */
    while (strcmp(fgets(input, BUFFER_LEN, stdin), "quit\n") != 0)
    {
        input_length = strlen(input); /* Get the input string length */
        input[--input_length] = '\0'; /* Remove newline at the end   */

        //删除运算表达式中的全部空格
        for (to = 0, index = 0; index <= input_length; index++)
            if (*(input + index) != ' ') //逐个字符判断是不是空格，不是的话就复制
                *(input + to++) = *(input + index);

        input_length = strlen(input);
        index = 0;

        if (input[index] == '=') //如果第一位是=，=表示上一次的运算结果，跳过，直接运算符
            index++;
        else
        {
            //查找左操作数
            //确认正负号，这里是正负号，而不是加和减
            number_length = 0;                                           /* Initialize length      */
            if (input[index] == '+' || input[index] == '-')              /* Is it + or -?  */
                *(number_string + number_length++) = *(input + index++); /* Yes so copy it */

            //复制接下来的全部数字
            for (; isdigit(*(input + index)); index++)                 /* Is it a digit? */
                *(number_string + number_length++) = *(input + index); /* Yes - Copy it  */

            //复制接下来的小数点以及小数点后面的全部数字
            if (*(input + index) == '.')                                 /* Is it decimal point? */
            {                                                            /* Yes so copy the decimal point and the following digits */
                *(number_string + number_length++) = *(input + index++); /* Copy point */

                for (; isdigit(*(input + index)); index++)                 /* For each digit */
                    *(number_string + number_length++) = *(input + index); /* copy it      */
            }
            *(number_string + number_length) = '\0'; /* Append string terminator */

            /* If we have a left operand, the length of number_string */
            /* will be > 0. In this case convert to a double so we    */
            /* can use it in the calculation                          */
            if (number_length > 0)
                result = atof(number_string); /* Store first number as result */
        }

        //获取运算符和右操作数并执行运算，代码同查找左操作数
        for (; index < input_length;)
        {
            op = *(input + index++); /* Get the operator */
            /* Copy the next operand and store it in number */
            number_length = 0; /* Initialize the length  */

            /* Check for sign and copy it */
            if (input[index] == '+' || input[index] == '-')              /* Is it + or -?  */
                *(number_string + number_length++) = *(input + index++); /* Yes - copy it. */

            /* Copy all following digits */
            for (; isdigit(*(input + index)); index++)                 /* For each digit */
                *(number_string + number_length++) = *(input + index); /* copy it.       */

            /* copy any fractional part */
            if (*(input + index) == '.') /* Is it a decimal point? */
            {                            /* Copy the  decimal point and the following digits */
                /* Copy point     */
                *(number_string + number_length++) = *(input + index++);
                for (; isdigit(*(input + index)); index++)                 /* For each digit */
                    *(number_string + number_length++) = *(input + index); /* copy it.     */
            }
            *(number_string + number_length) = '\0'; /* terminate string */

            /* Convert to a double so we can use it in the calculation */
            number = atof(number_string);

            /* Execute operation, as 'result op= number' */
            switch (op)
            {
            case '+':
                result += number;
                break;
            case '-':
                result -= number;
                break;
            case '*':
                result *= number;
                break;
            case '/':
                if (number == 0)
                    printf("\n\n\aDivision by zero error!\n");
                else
                    result /= number;
                break;
            case '%':
                if ((long)number == 0)
                    printf("\n\n\aDivision by zero error!\n");
                else
                    result = (double)((long)result % (long)number);
                break;
            case '^':
                result = pow(result, number);
                break;
            default:
                printf("\n\n\aIllegal operation!\n");
                break;
            }
        }

        printf("= %f\n", result);
    }

    return 0;
}
