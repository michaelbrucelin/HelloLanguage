#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int len = -1;
    printf("please input the length of array:\n");
    scanf("%d", &len);

    //int arr[len] = {0};  //这样是错的，数组的长度不能是变量
    int *arr = (int *)malloc(sizeof(int) * len); //这样就可以使用变量动态的申请内存了

    return (0);
}