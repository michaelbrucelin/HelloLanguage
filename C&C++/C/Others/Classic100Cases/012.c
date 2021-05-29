/*
题目：判断101到200之间的素数。

程序分析：判断素数的方法：用一个数分别去除2到sqrt(这个数)，如果能被整除， 则表明此数不是素数，反之是素数。
*/

#include <stdio.h>

int main(void)
{
    int i, j;
    int count = 0;

    for (i = 101; i <= 200; i++)
    {
        for (j = 2; j < i; j++)
        {
            // 如果j能被i整除在跳出循环
            if (i % j == 0)
                break;
        }
        // 判断循环是否提前跳出，如果j<i说明在2~j之间,i有可整除的数
        if (j >= i)
        {
            count++;
            printf("%d ", i);
            // 换行，用count计数，每五个数换行
            if (count % 5 == 0)
                printf("\n");
        }
    }

    return (0);
}