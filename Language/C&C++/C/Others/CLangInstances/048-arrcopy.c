#include <stdio.h>

int main()
{
    int original[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
    int copied[10];

    int i;
    for (i = 0; i < 10; i++)
    {
        copied[i] = original[i];
    }
    printf("元素数组 -> 拷贝后的数组 \n");

    for (i = 0; i < 10; i++)
    {
        printf("   %2d        %2d\n", original[i], copied[i]);
    }

    return 0;
}