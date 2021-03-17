#include <stdio.h>

/*
希尔排序
希尔排序，也称递减增量排序算法，是插入排序的一种更高效的改进版本。希尔排序是非稳定排序算法。
希尔排序是基于插入排序的以下两点性质而提出改进方法的：
1、插入排序在对几乎已经排好序的数据操作时，效率高，即可以达到线性排序的效率
2、但插入排序一般来说是低效的，因为插入排序每次只能将数据移动一位
*/

int main()
{
    int arr[] = {22, 34, 3, 32, 82, 55, 89, 50, 37, 5, 64, 35, 9, 70};

    int len = (int)sizeof(arr) / sizeof(*arr);
    void shell_sort(int arr[], int len);
    shell_sort(arr, len);

    int i;
    for (i = 0; i < len; i++)
    {
        printf("%d ", arr[i]);
    }

    printf("\n");

    return 0;
}

void shell_sort(int arr[], int len)
{
    int gap, i, j;
    int temp;
    for (gap = len >> 1; gap > 0; gap = gap >> 1)
    {
        for (i = gap; i < len; i++)
        {
            temp = arr[i];
            //for (j = i - gap; j >= 0 && arr[j] > temp; j -= gap)
            //{
            //    arr[j + gap] = arr[j];
            //}
            for (j = i - gap; j >= 0; j -= gap)
            {
                if (arr[j] > temp)
                {
                    arr[j + gap] = arr[j];
                }
                else
                {
                    break;
                }
            }
            arr[j + gap] = temp;
        }
    }
}