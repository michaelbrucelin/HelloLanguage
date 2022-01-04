#include <stdio.h>

/*
判断一个数是否为回文数。
设n是一任意自然数。若将n的各位数字反向排列所得自然数n1与n相等，则称n为一回文数。
例如，若n=1234321，则称n为一回文数；但若n=1234567，则n不是回文数。
*/

int main()
{
    int i;

    printf("input a number:");
    scanf("%d", &i);

    int myishuiwenshu(int input);
    int r = myishuiwenshu(i);
    if (r == 0)
        printf("%d is huiwenshu.\n", i);
    else
        printf("%d is not huiwenshu.\n", i);

    return 0;
}

int myishuiwenshu(int input)
{
    int r = 0, input0 = input;
    while (input > 0)
    {
        r = r * 10 + input % 10;
        input = input / 10;
    }

    if (r == input0)
        return 0;
    else
        return 1;
}