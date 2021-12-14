#include <stdio.h>

//使用递归实现一下快速排序法
//实现的有问题，还需要改

void myquicksort(int arr[], int left, int right);
void myswap(int *i, int *j);

int main(void)
{
    //int arr[] = {5, 2, 9, 4, 7, 8, 6, 3, 0, 1};  //当前排序算法有问题，这样就错了
    int arr[] = {50, 20, 90, 40, 70, 80, 60, 30, 10, 100};
    int len = sizeof(arr) / sizeof(arr[0]);

    for (int i = 0; i < len; i++)
        printf("%d\t", arr[i]);
    printf("\n");

    myquicksort(arr, 0, len - 1);

    for (int i = 0; i < len; i++)
        printf("%d\t", arr[i]);
    printf("\n");
}

void myquicksort(int arr[], int left, int right)
{
    //myswap(&arr[1], &arr[2]);
    int i = left, j = right;
    int pivot; //基准点
    pivot = arr[(left + right) / 2];
    while (i <= j)
    {
        //从左到右找到大于等于基准点的元素
        while (arr[i] < pivot)
            i++;
        //从右到左找到小于等于基准点的元素
        while (arr[j] > pivot)
            j--;
        if (i <= j)
        {
            myswap(&arr[i], &arr[j]);
            i++;
            j--;
        }
    }

    if (left < j)
        myquicksort(arr, left, j);
    if (i < right)
        myquicksort(arr, i, right);
}

void myswap(int *i, int *j)
{
    *i = *i ^ *j;
    *j = *j ^ *i;
    *i = *i ^ *j;
}