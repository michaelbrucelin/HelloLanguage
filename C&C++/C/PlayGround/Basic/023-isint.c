#include <stdio.h>
#include <math.h>

/*
判断一个浮点型是不是整型
*/

int main()
{
    double input;
    int i, r;

    printf("please input a number\n");
    scanf("%d", &i);

    input = sqrt(i);

    printf("%lf\n", input);

    i = input;
    if (input == i)
    {
        printf("is a integer.\n");
    }
    else
    {
        printf("not a integer.\n");
    }
}