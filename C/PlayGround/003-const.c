#include <stdio.h>

#define PRICE 30;

void main()
{
    int num, total;
    num = 10;
    total = num * PRICE;
    printf("total = %d\n", total);
}

// 习惯上常量都用大写字母，变量都用小写字母