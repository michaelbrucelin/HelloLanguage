#include <stdio.h>
#include <stdlib.h>

int k1 = 1;
int k2;
static int k3 = 2;
static int k4;

int main()
{
    static int m1 = 2, m2;
    int i = 1;
    char *p;
    char str[10] = "hello";
    char *q = "hello";
    p = (char *)malloc(100);
    free(p);
    printf("栈区-变量地址i\t\t: %p\n", &i);
    printf("p\t\t\t: %p\n", &p);
    printf("str\t\t\t: %p\n", str);
    printf("q\t\t\t: %p\n", &q);
    printf("堆区地址-动态申请\t: %p\n", p);
    printf("全局外部有初值k1\t: %p\n", &k1);
    printf("外部无初值k2\t\t: %p\n", &k2);
    printf("静态外部有初值k3\t: %p\n", &k3);
    printf("外静无初值k4\t\t: %p\n", &k4);
    printf("内静态有初值m1\t\t: %p\n", &m1);
    printf("内静态无初值m2\t\t: %p\n", &m2);
    printf("文字常量地址\t\t: %p, %s\n", q, q);
    printf("程序区地址\t\t: %p\n", &main);

    return (0);
}

/*
全局变量和局部变量在内存中的区别

gcc varposition.c
./a.out
> 栈区-变量地址i          : 0x7ffd55f6108c
> p                       : 0x7ffd55f61080
> str                     : 0x7ffd55f61076
> q                       : 0x7ffd55f61068
> 堆区地址-动态申请       : 0x5562147662a0
> 全局外部有初值k1        : 0x5562141e6040
> 外部无初值k2            : 0x5562141e6050
> 静态外部有初值k3        : 0x5562141e6044
> 外静无初值k4            : 0x5562141e6054
> 内静态有初值m1          : 0x5562141e6048
> 内静态无初值m2          : 0x5562141e6058
> 文字常量地址            : 0x5562141e4008, hello
> 程序区地址              : 0x5562141e3155
*/