#include <stdio.h>

int main()
{
    int a = 1, b = 2;

    void swap(int *a, int *b);
    swap(&a, &b);

    printf("a=%d\nb=%d\n", a, b);
    return 0;
}

void swap(int *a, int *b)
{
    int temp = *a;
    *a = *b;
    *b = temp;
}