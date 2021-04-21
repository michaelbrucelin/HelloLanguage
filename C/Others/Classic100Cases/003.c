/*
题目：一个整数，它加上100后是一个完全平方数，再加上168又是一个完全平方数，请问该数是多少？

程序分析：
假设该数为 x。
1、则：x + 100 = n2, x + 100 + 168 = m2
2、计算等式：m2 - n2 = (m + n)(m - n) = 168
3、设置： m + n = i，m - n = j，i * j =168，i 和 j 至少一个是偶数
4、可得： m = (i + j) / 2， n = (i - j) / 2，i 和 j 要么都是偶数，要么都是奇数。
5、从 3 和 4 推导可知道，i 与 j 均是大于等于 2 的偶数。
6、由于 i * j = 168， j>=2，则 1 < i < 168 / 2 + 1。
7、接下来将 i 的所有数字循环计算即可。
*/

#include <stdio.h>
#include <math.h>

int main(void)
{
    int result = -100;
    int isint(double input);

    //如果(i+1)*(i+1)-i*i > 168，即i > 84，之后就不会有结果了
    //sqrt(result+100) <= 85
    while (1)
    {
        if (sqrt(result + 100) > 84)
        {
            break;
        }

        if (isint(sqrt(result + 100)) == 0 && isint(sqrt(result + 100 + 168)) == 0)
        {
            printf("%d\n", result);
        }

        result++;
    }

    return (0);
}

//判断浮点型是不是整型，是返回0，否则返回1
int isint(double input)
{
    int i = input;
    if (input == i)
    {
        return 0;
    }
    else
    {
        return 1;
    }
}