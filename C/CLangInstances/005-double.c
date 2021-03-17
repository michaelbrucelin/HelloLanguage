#include <stdio.h>

/*
使用 printf() 与 %e 输出双精度数。
*/

int main()
{
    double d; // 声明双精度变量

    d = 12.001234; // 定义双精度变量

    printf("d 的值为 %le", d);

    return 0;
}