#include <stdio.h>
#include <math.h>

/*
八进制转换为二进制
*/

long long convertOctalToBinary(int octalNumber);
int main()
{
    int octalNumber;

    printf("输入一个八进制数: ");
    scanf("%d", &octalNumber);

    printf("八进制数 %d 转二进制为 %lld", octalNumber, convertOctalToBinary(octalNumber));

    return 0;
}

long long convertOctalToBinary(int octalNumber)
{
    int decimalNumber = 0, i = 0;
    long long binaryNumber = 0;

    while (octalNumber != 0)
    {
        decimalNumber += (octalNumber % 10) * pow(8, i);
        ++i;
        octalNumber /= 10;
    }

    i = 1;

    while (decimalNumber != 0)
    {
        binaryNumber += (decimalNumber % 2) * i;
        decimalNumber /= 2;
        i *= 10;
    }

    return binaryNumber;
}