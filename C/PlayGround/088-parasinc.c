#include <stdio.h>
#include <stdlib.h>
#include <stdarg.h>

//C语言中函数的可变参数，对应C#中的paras[]

int mysum_int(int cnt, ...);

int main(void)
{
    int cnt = 0;
    printf("please input the count of numbers:\n");
    scanf("%d", &cnt);

    int *arr = (int *)malloc(sizeof(int) * cnt);
    for (size_t i = 0; i < cnt; i++)
    {
        printf("please input number_%d: ", i + 1);
        scanf("%d", arr + i);
    }
    printf("%d\n", mysum_int(cnt, arr)); //不支持动态数组，不知道有没有其他写法可以支持

    int arr1[4] = {1, 2, 3, 4};
    printf("%d\n", mysum_int(cnt, arr1)); //不支持数组，不知道有没有其他写法可以支持

    printf("%d\n", mysum_int(4, 1, 2, 3, 4));

    return (0);
}

int mysum_int(int cnt, ...)
{
    int sum = 0;

    va_list vap;
    //cnt卸载va_start()中表示，函数的参数列表，cnt之后的参数，就都是可变参数的意思，即cnt是函数参数列中最后一个固定的参数
    //这里例子中的cnt是可变函数的数量，有一定的混淆，实际上不需要知道可变参数的数量的，具体可以参见下一个例子
    va_start(vap, cnt);
    for (int i = 0; i < cnt; i++)
    {
        sum += va_arg(vap, int);
    }
    va_end(vap);

    return sum;
}