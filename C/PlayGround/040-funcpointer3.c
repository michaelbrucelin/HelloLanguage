#include <stdio.h>

//函数指针，实现类似于C#中的委托，OO中的多态
//借用函数指针数组再实现一次

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

    int (*pfunarr[3])(int, int);
    pfunarr[0] = getmax;
    pfunarr[1] = getmin;
    pfunarr[2] = getsum;

    for (size_t i = 0; i < 3; i++)
    {
        printf("%s number is %d\n",
               i == 0 ? "max" : i == 1 ? "min" : "sum",
               (*p)(a, b, pfunarr[i]));
    }
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