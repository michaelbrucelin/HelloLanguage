#include <stdio.h>

void main()
{
    char c;
    printf("input a character\n");
    c = getchar();
    printf("your input is ");
    putchar(c);
    putchar('\n');
}