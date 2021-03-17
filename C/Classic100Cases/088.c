/*
题目：读取7个数（1—50）的整数值，每读取一个值，程序打印出该值个数的 ＊。

程序分析：无。
*/

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int n, i, j;
    printf("请输入数字:\n");
    i--;
    for (i = 0; i < 7; i++)
    {
        scanf("%d", &n);
        if (n > 50)
        {
            printf("请重新输入:\n");
            i--;
        }
        else
        {
            for (j = 0; j < n; j++)
                printf("*");
        }
        printf("\n");
    }

    return (0);
}