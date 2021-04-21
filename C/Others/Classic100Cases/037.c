/*
题目：对10个数进行排序。

程序分析：可以利用选择法，即从后9个比较过程中，选择一个最小的与第一个元素交换， 下次类推，即用第二个元素与后8个进行比较，并进行交换。
*/

#include <stdio.h>

#define N 10

int main(void)
{
    int i, j, a[N], temp;
    printf("请输入 10 个数字：\n");
    for (i = 0; i < N; i++)
        scanf("%d", &a[i]);
    for (i = 0; i < N - 1; i++)
    {
        int min = i;
        for (j = i + 1; j < N; j++)
            if (a[min] > a[j])
                min = j;
        if (min != i)
        {
            temp = a[min];
            a[min] = a[i];
            a[i] = temp;
        }
    }
    printf("排序结果是:\n");
    for (i = 0; i < N; i++)
        printf("%d ", a[i]);
    printf("\n");

    return (0);
}