#include <stdio.h>

/*
使用 for 循环迭代出输出元素，并将各个元素相加算出总和，再除于元素个数：
*/

int main()
{
    int n, i;
    float num[100], sum = 0.0, average;

    printf("输入元素个数: ");
    scanf("%d", &n);

    while (n > 100 || n <= 0)
    {
        printf("Error! 数字需要在1 到 100 之间。\n");
        printf("再次输入: ");
        scanf("%d", &n);
    }

    for (i = 0; i < n; ++i)
    {
        printf("%d. 输入数字: ", i + 1);
        scanf("%f", &num[i]);
        sum += num[i];
    }

    average = sum / n;
    printf("平均值 = %.2f", average);

    return 0;
}