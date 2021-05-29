#include <stdio.h>

/*
a、b、c 三个变量，通过引用按顺序循环替换他们的值。
*/

int main()
{
    int a, b, c;

    printf("输入 a, b 和 c 的值: ");
    scanf("%d %d %d", &a, &b, &c);

    printf("交换前:\n");
    printf("a = %d \nb = %d \nc = %d\n", a, b, c);

    void cyclicSwap(int *a, int *b, int *c);
    cyclicSwap(&a, &b, &c);

    printf("交换后:\n");
    printf("a = %d \nb = %d \nc = %d\n", a, b, c);

    return 0;
}

void cyclicSwap(int *a, int *b, int *c)
{
    int temp;

    temp = *a;
    *a = *b;
    *b = *c;
    *c = temp;
}