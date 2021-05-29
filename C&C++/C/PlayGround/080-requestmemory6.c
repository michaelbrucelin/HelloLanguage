#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//如果不适用relloc()函数，手动重新申请内存空间并将值复制过去

#define N1 8
#define N2 16

int main(void)
{
    int *ptr1 = NULL;
    int *ptr2 = NULL;

    //第一次申请
    ptr1 = (int *)malloc(N1 * sizeof(int));
    if (ptr1 == NULL)
        exit(1);
    for (size_t i = 0; i < N1; i++)
        ptr1[i] = i + 97;

    //第二次申请
    ptr2 = (int *)malloc(N2 * sizeof(int));
    if (ptr2 == NULL)
        exit(1);

    //复制值
    memcpy(ptr2, ptr1, N1 * sizeof(int));
    free(ptr1);
    for (size_t i = 8; i < N2; i++)
        ptr2[i] = i + 65 - 8;

    for (size_t i = 0; i < N2; i++)
        printf("%c  ", ptr2[i]);
    printf("\n");

    free(ptr2);

    return (0);
}