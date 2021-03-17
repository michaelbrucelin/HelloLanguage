#include <stdio.h>

/*
插入排序
插入排序（英语：Insertion Sort）是一种简单直观的排序算法。
它的工作原理是通过构建有序序列，对于未排序数据，在已排序序列中从后向前扫描，找到相应位置并插入。
插入排序在实现上，通常采用in-place排序（即只需用到 {\displaystyle O(1)} {\displaystyle O(1)}的额外空间的排序），
因而在从后向前扫描过程中，需要反复把已排序元素逐步向后挪位，为最新元素提供插入空间。
    先用第2个元素与第1个元素作比较
        如果第1个元素比第2个元素大，就把第1个元素放到第2个的位置；然后把第2个元素放到第1个元素的位置
        这样就保证了前两个元素是有序的
    然后用第3个元素与前面2个元素逐个比较
        如果第2个元素比第3个元素大，就把第2个元素放到第3个的位置；
        如果第1个元素比第3个元素小，停止比较；
        如果第1个元素比第3个元素大，就把第1个元素放到第2个的位置，然后把第3个元素放到第1个元素的位置
        这样就保证了前3个元素是有序的
    然后用第4个元素与前面3个元素逐个比较
        ... ...
    最后得到有序的数组。
*/

int main()
{
    int arr[] = {22, 34, 3, 32, 82, 55, 89, 50, 37, 5, 64, 35, 9, 70};

    int len = (int)sizeof(arr) / sizeof(*arr);
    void insertion_sort(int arr[], int len);
    insertion_sort(arr, len);

    int i;
    for (i = 0; i < len; i++)
    {
        printf("%d ", arr[i]);
    }

    printf("\n");

    return 0;
}

void insertion_sort(int arr[], int len)
{
    int i, j, temp;
    for (i = 1; i < len; i++)
    {
        temp = arr[i];
        //for (j = i; j > 0 && arr[j - 1] > temp; j--)
        //{
        //    arr[j] = arr[j - 1];
        //}
        for (j = i; j > 0; j--)
        {
            if (arr[j - 1] > temp)
            {
                arr[j] = arr[j - 1];
            }
            else
            {
                break;
            }
        }
        arr[j] = temp;
    }
}