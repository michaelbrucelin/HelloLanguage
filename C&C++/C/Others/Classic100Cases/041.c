/*
题目：学习static定义静态变量的用法。

程序分析：无。
*/

#include <stdio.h>

int main(void)
{
    void fun();
    for (int i = 0; i < 3; i++)
        fun();

    return (0);
}

void fun()
{
    int i = 0;
    static int static_i = 0;
    printf("i=%d\n", i);
    printf("static_i=%d\n", static_i);
    i++;
    static_i++;
}