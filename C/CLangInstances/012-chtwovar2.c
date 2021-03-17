#include <stdio.h>

int main()
{
    int a, b;

    a = 11;
    b = 99;

    printf("交换之前 - \n a = %d, b = %d \n\n", a, b);

    a = a + b; // ( 11 + 99 = 110)  此时 a 的变量为两数之和，b 未改变
    b = a - b; // ( 110 - 99 = 11)
    a = a - b; // ( 110 - 11 = 99)

    printf("交换后 - \n a = %d, b = %d \n", a, b);
}