/*
题目：宏#define命令练习2。

程序分析：无。
*/

#include <stdio.h>

#define exchange(a, b) \
    {                  \
        int t;         \
        t = a;         \
        a = b;         \
        b = t;         \
    } //注意放在一行里

int main(void)
{
    int x = 10;
    int y = 20;
    printf("x=%d; y=%d\n", x, y);
    exchange(x, y);
    printf("x=%d; y=%d\n", x, y);

    return (0);
}