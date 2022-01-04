#include <stdio.h>
#include <math.h>

/*
用户输入数字，判断该数字是几位数。
*/

int main()
{
    int i;

    printf("input a number:");
    scanf("%d", &i);

    int mydigitlen(int input);
    printf("%d length is %d.\n", i, mydigitlen(i));

    return 0;
}

int mydigitlen(int input)
{
    //int的范围：-2147483648~2147483647，所以做多10位
    for (int i = 1; i <= 9; i++)
    {
        if (input < pow(10, i))
        {
            return i;
        }
    }

    return 10;
}