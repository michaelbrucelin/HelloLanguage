/*
题目：有n个人围成一圈，顺序排号。从第一个人开始报数（从1到3报数），凡报到3的人退出圈子，问最后留下的是原来第几号的那位。

程序分析：使用数组实现。
*/

#include <stdio.h>
#include <stdlib.h>

#define N 3 //报3的人移除

void printarr(int *arr, int count);

int main(void)
{
    int *arr, left, baoshu = 1, count = 0;

    printf("请输入人员的数量： ");
    scanf("%d", &count);

    arr = (int *)malloc(count);
    if (arr == NULL)
    {
        printf("没有足够的内存空间。\n");
        return 1;
    }

    left = count;
    for (size_t i = 0; i < count; i++)
    {
        *(arr + i) = i + 1;
    }
    //printarr(arr, count);

    while (left > 1)
    {
        for (size_t i = 0; i < count; i++)
        {
            if (*(arr + i) != 0)
                if (((baoshu++ - 1) % 3 + 1) == N)
                {
                    *(arr + i) = 0;
                    left--;
                }
        }
    }

    for (size_t i = 0; i < count; i++)
    {
        if (*(arr + i) != 0)
        {
            printf("[array]余下第%d号人。\n", i + 1);
            break;
        }
    }

    free(arr);

    return (0);
}

void printarr(int *arr, int count)
{
    for (size_t i = 0; i < count; i++)
        printf("%d  ", *(arr + i));
    printf("\n");
}