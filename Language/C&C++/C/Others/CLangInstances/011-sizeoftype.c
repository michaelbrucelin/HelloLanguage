#include <stdio.h>

/*
使用 sizeof 操作符计算int, float, double 和 char四种变量字节大小。
sizeof 是 C 语言的一种单目操作符，如C语言的其他操作符++、--等，它并不是函数。
sizeof 操作符以字节形式给出了其操作数的存储大小。
*/

int main()
{
    int integerType;
    float floatType;
    double doubleType;
    char charType;

    // sizeof 操作符用于计算变量的字节大小
    printf("Size of int: %ld bytes\n", sizeof(integerType));
    printf("Size of float: %ld bytes\n", sizeof(floatType));
    printf("Size of double: %ld bytes\n", sizeof(doubleType));
    printf("Size of char: %ld byte\n", sizeof(charType));

    return 0;
}