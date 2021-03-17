#include <stdio.h>

int main()
{
    int a, b;

    printf("输入第一个值:");
    scanf("%d", &a);
    printf("输入第二个值:");
    scanf("%d", &b);

    if (a > b)
        printf("a 大于 b");
    else
        printf("a 小于等于 b");

    return 0;
}