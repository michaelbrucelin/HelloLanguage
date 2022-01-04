#include <stdio.h>
#include <stdlib.h>

//用户每输入一个数字，就动态增加数组的长度

int main(void)
{
    int i, num;
    int count = 0;
    int *ptr = NULL; //下面直接使用realloc()申请内存空间，所以这里一定要赋值为NULL

    do
    {
        printf("please input a int(input -1 to exit): ");
        scanf("%d", &num);
        count++;

        ptr = (int *)realloc(ptr, count * sizeof(int));
        if (ptr == NULL)
            exit(1);
        ptr[count - 1] = num;
    } while (num != -1);

    printf("your input is: ");
    for (size_t i = 0; i < count; i++)
        printf("%d  ", ptr[i]);
    putchar('\n');

    free(ptr);

    return (0);
}