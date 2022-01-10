#include <stdio.h>

/*
利用宏，不用循环和递归，实现打印0-999
很多世界编程大赛中的代码，都是用宏来简化
*/

#define A(x) x;x;x;x;x;x;x;x;x;x;  // 宏将x重复10次，并输出，main函数中嵌套调用了3次，所以输出了power(10,3)次，即1000次

int main(void)
{
    int n = 0;

    A(A(A(printf("%d\t", n++))));
    printf("\n");

    return 0;
}