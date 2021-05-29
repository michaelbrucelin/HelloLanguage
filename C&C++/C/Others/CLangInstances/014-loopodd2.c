#include <stdio.h>

int main()
{
    for (int i = 1; i < 10; i++)
        // 通过按位与运算符判断奇偶数
        i & 1 ? printf("奇数: %d\n", i) : printf("偶数: %d\n", i);
}