#include <stdio.h>

void main()
{
    int a, b, c;
    printf("input a,b,c\n");
    scanf("%d%d%d", &a, &b, &c); //直接将读取到的值放入指定的内存中，&a是变量a的内存地址
    printf("a=%d, b=%d, c=%d\n", a, b, c);
    printf("&a=%p, &b=%p, &c=%p\n", &a, &b, &c); //%p输出的是指针地址
    printf("&a=%s, &b=%s, &c=%s\n", &a, &b, &c);
}