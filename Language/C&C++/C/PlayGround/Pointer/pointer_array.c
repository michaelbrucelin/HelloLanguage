#include <stdio.h>

int main()
{
    int arr[10] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    int *p = &arr[5];

    printf("int *p = &arr[5];\n");
    printf("*p:\t%d\n", *p);
    printf("*(p+2):\t%d\n", *(p + 2));
    printf("*(p-2):\t%d\n", *(p - 2)); // 也可以向前索引，只要不数组越界就好
}