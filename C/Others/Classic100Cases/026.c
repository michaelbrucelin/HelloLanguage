/*
题目：利用递归方法求5!。

程序分析：递归公式：fn=fn_1*4!
*/

#include <stdio.h>

int main(void)
{
    int i;
    int fact(int);
    for (i = 0; i < 6; i++)
    {
        printf("%d!=%d\n", i, fact(i));
    }

    return (0);
}

int fact(int j)
{
    int sum;
    if (j == 0)
    {
        sum = 1;
    }
    else
    {
        sum = j * fact(j - 1);
    }

    return sum;
}