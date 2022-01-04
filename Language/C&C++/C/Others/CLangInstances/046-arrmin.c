#include <stdio.h>

int main()
{
    int array[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

    int i, min = array[0];
    for (i = 1; i < 10; i++)
    {
        if (min > array[i])
            min = array[i];
    }

    printf("最小元素为 %d", min);

    return 0;
}