#include <stdio.h>

/*
选择排序
选择排序（Selection sort）是一种简单直观的排序算法。
它的工作原理如下：
首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置，然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
以此类推，直到所有元素均排序完毕。
    这里使用第1个元素与后面的元素逐个比较，这样将最小的元素拿到最前面；
    再使用第2个元素与后面的元素逐个比较，将最小的元素拿到第2个位置；
    再使用第3个元素与后面的元素逐个比较，将最小的元素拿到第3个位置；
    ...
    有递归的意思，传统意义上的选择排序的变种，没有使用临时变量存取最小（大）值，而是直接替换到指定的位置；
*/

int main()
{
    int arr[] = {22, 34, 3, 32, 82, 55, 89, 50, 37, 5, 64, 35, 9, 70};

    int len = (int)sizeof(arr) / sizeof(*arr);
    void selection_sort(int arr[], int len);
    selection_sort(arr, len);

    int i;
    for (i = 0; i < len; i++)
    {
        printf("%d ", arr[i]);
    }

    printf("\n");

    return 0;
}

void selection_sort(int arr[], int len)
{
    void swap(int *a, int *b);

    int i, j;
    for (i = 0; i < len - 1; i++)
    {
        for (j = i + 1; j < len; j++)
        {
            if (arr[i] > arr[j])
            {
                swap(&arr[i], &arr[j]);
            }
        }
    }
}

void swap(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}