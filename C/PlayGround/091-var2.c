#include <stdio.h>

//全局变量

int count = 0; //定义全局变量

void test1(void);
void test2(void);

int main(void)
{
    int count = 0; //main函数中的本地自动变量会隐藏全局变量

    for (; count < 5; count++)
    {
        test1();
        test2();
    }
    return 0;
}

//test1中使用全局变量
void test1(void)
{
    printf("test1 count = %d\t", ++count);
}

//test2中使用静态变量
void test2(void)
{
    static int count; //test2中的本地静态变量会隐藏全局变量
    printf("test2 count = %d\n", ++count);
}