#include <stdio.h>

//静态变量，默认情况下声明的变量为自动变量

void test1(void);
void test2(void);

int main(void)
{
    for (int i = 0; i < 5; i++)
    {
        test1();
        test2();
    }

    return 0;
}

//test1中使用自动变量
void test1(void)
{
    int count = 0;
    printf("test1 count = %d\t", ++count);
}

//test2中使用静态变量
void test2(void)
{
    static int count = 0;
    printf("test2 count = %d\n", ++count);
}