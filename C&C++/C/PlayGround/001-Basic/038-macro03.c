#include <stdio.h>

#define SQMACRO(x) ((x)*(x))

int main(void)
{
    int i = 1;
    int SQFUNC(int x);

    printf("print the macro result\n");
    while (i < 5)
    {
        printf("%d\t", SQMACRO(i++));
    }
    printf("\n");

    i = 1;
    printf("print the function result\n");
    while (i < 5)
    {
        printf("%d\t", SQFUNC(i++));
    }
    printf("\n");
}

int SQFUNC(int x)
{
    return ((x) * (x));
}