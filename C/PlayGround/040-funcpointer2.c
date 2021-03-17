#include <stdio.h>

//函数指针，实现类似于C#中的委托，OO中的多态

int process(int, int, int (*p)());
int getmax(int, int);
int getmin(int, int);
int getsum(int, int);

int main()
{
    int a, b;
    printf("input two numbers:\n");
    scanf("%d %d", &a, &b);

    int (*p)(int, int, int (*p)(int, int));
    p = process;

    printf("max number is %d\n", (*p)(a, b, getmax));
    printf("min number is %d\n", (*p)(a, b, getmin));
    printf("sum number is %d\n", (*p)(a, b, getsum));
}

int process(int a, int b, int (*p)(int, int))
{
    return (*p)(a, b);
}

int getmax(int a, int b)
{
    return a > b ? a : b;
}

int getmin(int a, int b)
{
    return a < b ? a : b;
}

int getsum(int a, int b)
{
    return a + b;
}