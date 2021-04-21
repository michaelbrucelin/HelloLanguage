/*
题目：#include 的应用练习。

程序分析：无。
*/

#include <stdio.h>
#include "050.h"

int main(void)
{
    int i = 10;
    int j = 20;
    if (i LAG j)
        printf("%d 大于 %d \n", i, j);
    else if (i EQ j)
        printf("%d 等于 %d \n", i, j);
    else if (i SMA j)
        printf("%d 小于 %d \n", i, j);
    else
        printf("没有值。\n");

    return (0);
}