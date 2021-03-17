#include <stdio.h>

int main()
{
    int array[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

    int i, max = array[0];
    for (i = 1; i < 10; i++)
    {
        if (max < array[i])
            max = array[i];
    }

    printf("最大元素为 %d", max);

    return 0;
}