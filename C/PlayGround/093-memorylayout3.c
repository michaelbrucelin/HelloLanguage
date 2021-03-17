#include <stdio.h>

int main(void)
{
    char a = 0, b = 0;
    int *p = (int *)&b;

    *p = 258;

    printf("a=%d b=%d\n", a, b);

    return (0);
}

/*
结果为0 2，为什么？在32位操作系统上打印的结果为1 2
# ./a.out 
a=0 b=2
*/