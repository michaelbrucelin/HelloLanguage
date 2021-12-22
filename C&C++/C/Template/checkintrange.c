// C program to print values of INT_MIN and INT_MAX
// we have to include limits.h for results in C
#include <stdio.h>
#include <limits.h>

int main()
{
    printf("min int: %d\n", INT_MIN);
    printf("max int: %d\n", INT_MAX);
}

/*
C语言在不同的编译器下，int的最大值和最小值是不同的。
投入生产环境前，最好在生产环境中验证一下。
*/