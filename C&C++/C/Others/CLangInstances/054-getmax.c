#include <stdio.h>
#include <stdlib.h>

/*
通过用户输入指定的数值，来判断最大值。
*/

int main()
{
    int i, num;
    float *data;

    printf("输入元素个数(1 ~ 100): ");
    scanf("%d", &num);

    // 为 'num' 元素分配内存
    data = (float *)calloc(num, sizeof(float));

    if (data == NULL)
    {
        printf("Error!!! 内存没有分配。\n");
        exit(0);
    }

    printf("\n");

    // 用户输入
    for (i = 0; i < num; ++i)
    {
        printf("输入数字 %d: ", i + 1);
        scanf("%f", data + i);
    }

    // 循环找出最大值
    for (i = 1; i < num; ++i)
    {
        // 如果需要找出最小值可以将 < 改为 >
        if (*data < *(data + i))
        {
            *data = *(data + i);
        }
    }

    printf("最大元素 = %.2f\n", *data);

    return 0;
}