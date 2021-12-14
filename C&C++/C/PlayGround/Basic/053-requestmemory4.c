#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//初始化内存空间

#define N 10

int main(void)
{
    int *ptr = NULL;
    int i;

    ptr = (int *)malloc(N * sizeof(int));
    if (ptr == NULL)
    {
        exit(1);
    }

    /*
    或者直接使用calloc()函数，calloc()函数会自动初始化内存空间为0，所以说下面二者等价
    int *ptr = (int *)calloc(8, sizeof(int));
    或
    int *ptr = (int *)malloc(8 * sizeof(int));
    memset(ptr, 0, 8 * sizeof(int));
    */
    memset(ptr, 0, N * sizeof(int)); //初始化申请的内存空间为0
    for (size_t i = 0; i < N; i++)
    {
        printf("%d  ", ptr[i]);
    }
    putchar('\n');

    free(ptr);

    return (0);
}