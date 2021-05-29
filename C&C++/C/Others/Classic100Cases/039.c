/*
题目：有一个已经排好序的数组。现输入一个数，要求按原来的规律将它插入数组中。

程序分析：首先判断此数是否大于最后一个数,然后再考虑插入中间的数的情况,插入后此元素之后的数,依次后移一个位置。
*/

#include <stdio.h>

int main(void)
{
    int a[11] = {1, 4, 6, 9, 13, 16, 19, 28, 40, 100};
    int temp1, temp2, number, end, i, j;
    printf("原始数组是:\n");
    for (i = 0; i < 10; i++)
        printf("%4d", a[i]);
    printf("\n插入一个新的数字: ");
    scanf("%d", &number);
    end = a[9];
    if (number > end)
        a[10] = number;
    else
    {
        for (i = 0; i < 10; i++)
        {
            if (a[i] > number)
            {
                temp1 = a[i];
                a[i] = number;
                for (j = i + 1; j < 11; j++)
                {
                    temp2 = a[j];
                    a[j] = temp1;
                    temp1 = temp2;
                }
                break;
            }
        }
    }
    for (i = 0; i < 11; i++)
        printf("%4d", a[i]);
    printf("\n");

    return (0);
}