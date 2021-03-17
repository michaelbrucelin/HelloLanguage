/*
题目：输出9*9口诀。

程序分析：分行与列考虑，共 9 行 9 列，i 控制行，j 控制列。
*/

#include <stdio.h>

int main(void)
{
    int i, j, result;
    printf("\n");
    for (i = 1; i < 10; i++)
    {
        for (j = 1; j <= i; j++)
        {
            result = i * j;
            printf("%d*%d=%-3d", i, j, result); /*-3d表示左对齐，占3位*/
        }
        printf("\n"); /*每一行后换行*/
    }

    return (0);
}