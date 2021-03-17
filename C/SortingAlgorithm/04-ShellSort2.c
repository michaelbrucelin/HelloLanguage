#include <stdio.h>

/*
希尔排序
希尔排序，也称递减增量排序算法，是插入排序的一种更高效的改进版本。希尔排序是非稳定排序算法。
希尔排序是基于插入排序的以下两点性质而提出改进方法的：
1、插入排序在对几乎已经排好序的数据操作时，效率高，即可以达到线性排序的效率
2、但插入排序一般来说是低效的，因为插入排序每次只能将数据移动一位
    这里使用二分法查找第n个元素应该在的位置，而不是使用传统二分法使用第n个元素与前面n-1个元素逐个比较的方式
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
    int i, a, z, mid, temp;

    //查找应该插入的位置
    for (i = 1; i < len; i++)
    {
        temp = arr[i];
        a = 0, z = i - 1, mid = (i - 1) / 2;
        while (z - a > 1)
        {
            if (arr[mid] == temp)
            {
                a = z = mid; //后面的比较需要用到a和z
                break;
            }
            else if (arr[mid] > temp)
            {
                z = mid;
            }
            else
            {
                a = mid;
            }
            mid = (a + z) / 2;
        }

        //此时，只有 a==z 与 a+1==z 两种可能，而temp的值也一定在arr[a-1]与arr[z+1]之间
        //所以如果arr[a]>temp，就把temp插入到arr[a]的位置即可
        //    如果arr[z]<temp，就把temp插入到arr[z+1]的位置即可
        //    否则，arr[a]<=temp<=arr[z]，就把temp插入到arr[z]的位置即可
        if (arr[a] > temp)
        {
            mid = a;
        }
        else if (arr[z] < temp)
        {
            mid = z + 1;
        }
        else
        {
            mid = z;
        }

        //移动元素
        for (int j = i; j > mid; j--)
        {
            arr[j] = arr[j - 1];
        }

        //插入元素
        arr[mid] = temp;
    }
}