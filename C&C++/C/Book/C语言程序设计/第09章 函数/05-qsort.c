/* Sorts an array of integers using Quicksort algorithm */
#include <stdio.h>

#define N 10

void quicksort(int a[], int low, int high);
int split(int a[], int low, int high);

int main(void)
{
    int a[N], i;

    printf("Enter %d numbers to be sorted: ", N);
    for (i = 0; i < N; i++)
        scanf("%d", &a[i]);

    quicksort(a, 0, N - 1);
    printf("In sorted order: ");

    for (i = 0; i < N; i++)
        printf("%d ", a[i]);
    printf("\n");

    return 0;
}

void quicksort(int a[], int low, int high)
{
    int middle;

    if (low >= high)
        return;

    middle = split(a, low, high);
    quicksort(a, low, middle - 1);
    quicksort(a, middle + 1, high);
}

int split(int a[], int low, int high)
{
    int part_element = a[low];

    for (;;)
    {
        while (low < high && part_element <= a[high])
            high--;
        if (low >= high)
            break;
        a[low++] = a[high];
        while (low < high && a[low] <= part_element)
            low++;
        if (low >= high)
            break;
        a[high--] = a[low];
    }
    a[high] = part_element;

    return high;
}

/*
虽然此版本的快速排序可行，但是它不是最好的。有许多方法可以用来改进这个程序的性能。
- 改进分割算法
    上面介绍的方法不是最有效的。我们不再选择数组中的第一个元素作为分割元素，更好的方法是取第一个元素、中间元素和最后一个元素的中间值。
    分割过程本身也可以加速。特别是，在两个while 循环中避免测试low < high是可能的。

- 采用不同的方法进行小数组排序
    不再递归地使用快速排序法用一个元素全部下至数组尾，针对小数组（比方说，拥有的元素数量少于25个的数组）更好的方法是采用较为简单的方法。

- 使得快速排序非递归
    虽然快速排序本质上是递归算法，并且递归格式的快速排序是最容易理解的，但是实际上若去掉递归会更高效。
*/