#include <stdio.h>

int main()
{
    int *p, i, arr[10];
    p = arr;

    printf("请输入10个整数\n");
    for (int i = 0; i < 10; i++)
    {
        scanf("%d", p++);
    }
    printf("\n");

    for (p = arr; p < (arr + 10); p++)
    {
        printf("%d ", *p);
    }
    printf("\n");
}