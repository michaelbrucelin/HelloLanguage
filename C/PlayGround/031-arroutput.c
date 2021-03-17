#include <stdio.h>

int main()
{
    int arr[10] = {0, 1, 4, 9, 16, 25, 36, 49, 64, 81};

    //1. 通过数组下标输出
    printf("通过数组下标输出\n");
    for (int i = 0; i < 10; i++)
    {
        printf("%d\t", arr[i]);
    }
    printf("\n");

    //2. 通过数组名计算数组元素的地址，然后输出
    printf("通过数组名计算数组元素的地址，然后输出\n");
    for (int i = 0; i < 10; i++)
    {
        printf("%d\t", *(arr + i));
    }
    printf("\n");

    //3. 通过指针变量指向数组元素，然后输出
    printf("通过指针变量指向数组元素，然后输出\n");
    int *p = arr;
    for (int i = 0; i < 10; i++)
    {
        printf("%d\t", *(p + i));
    }
    printf("\n");
}