#include <stdio.h>

/*
冒泡排序
冒泡排序（英语：Bubble Sort）是一种简单的排序算法。
它重复地走访过要排序的数列，一次比较两个元素，如果他们的顺序（如从大到小、首字母从A到Z）错误就把他们交换过来。
    这里使用第1个元素与第2个元素比较，使用第2个元素与第3个元素比较...直到倒第2个元素与倒第1个元素比较，将最大的元素拿到最后；
    再使用第1个元素与第2个元素比较，使用第2个元素与第3个元素比较...直到倒第3个元素与倒第2个元素比较，将最大的元素拿到最后倒数第2个位置；
    再使用第1个元素与第2个元素比较，使用第2个元素与第3个元素比较...直到倒第4个元素与倒第3个元素比较，将最大的元素拿到最后倒数第3个位置；
    ...
    传统意义上的冒泡排序；
*/

int main()
{
    int arr[] = {22, 34, 3, 32, 82, 55, 89, 50, 37, 5, 64, 35, 9, 70};

    int len = (int)sizeof(arr) / sizeof(*arr);
    void bubble_sort(int arr[], int len);
    bubble_sort(arr, len);

    int i;
    for (i = 0; i < len; i++)
    {
        printf("%d ", arr[i]);
    }

    printf("\n");

    return 0;
}

void bubble_sort(int arr[], int len)
{
    void swap(int *a, int *b);

    int i, j;
    for (i = 0; i < len - 1; i++)
    {
        for (j = 0; j < len - 1 - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                swap(&arr[j], &arr[j + 1]);
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