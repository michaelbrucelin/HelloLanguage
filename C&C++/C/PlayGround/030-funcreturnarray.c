#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main()
{
    /* 一个指向整数的指针 */
    int *p;
    int i;

    int *getRandom();
    p = getRandom();
    for (i = 0; i < 10; i++)
    {
        printf("*(p + %d) : %d\n", i, *(p + i)); //这里i为什么步长为1，而不是4？int的size不是4吗？
    }

    return 0;
}

int *getRandom()
{
    static int r[10];
    int i;

    /* 设置种子 */
    srand((unsigned)time(NULL));
    for (i = 0; i < 10; ++i)
    {
        r[i] = rand();
        printf("r[%d] = %d\n", i, r[i]);
    }

    return r;
}