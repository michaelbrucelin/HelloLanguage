#include <stdio.h>

/*
使用嵌套 for 循环输出九九乘法口诀表。
*/

int main()
{
    for (int i = 1; i <= 9; i++)
    {
        for (int j = 1; j <= i; j++)
        {
            printf("%d * %d = %d\t", i, j, i * j);
        }
        printf("\n");
    }

    return 0;
}