#include <stdio.h>

//函数指针，实现类似于C#中的委托，OO中的多态

int getmax(int, int);

int main()
{
    int a, b, c;
    printf("input two numbers");
    scanf("%d %d", &a, &b);

    int (*p)(int, int);

    p = getmax;
    printf("max number is %d\n", (*p)(a, b));
}

int getmax(int a, int b)
{
    return a > b ? a : b;
}