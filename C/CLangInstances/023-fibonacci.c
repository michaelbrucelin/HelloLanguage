#include <stdio.h>

/*
斐波那契数列指的是这样一个数列 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233，377，610，987，1597，2584，4181，6765，10946，17711，28657，46368 ... ...
这个数列从第3项开始，每一项都等于前两项之和。
*/

int main()
{
    int n;

    printf("input a number:");
    scanf("%d", &n);

    int *myfibonacci(int n);
    int *pointer = myfibonacci(n);

    for (int i = 0; i < n + 1024; i++) //返回的数组长度要比n长，这里loop的时候选择上界为n+1024
    {
        if (*(pointer + i) != 0)
        {
            printf("*(p + %d):\t%d\n", i, *(pointer + i));
        }
        else
        {
            break;
        }
    }

    return 0;
}

//C语言中函数的返回值不可以为数组，但是可以通过返回数组的指针来实现返回数组类型
//另外，C语言不支持在函数外返回局部变量的地址，除非定义局部变量为static变量
int *myfibonacci(int n)
{
    static int result[100]; //数组长度不可以是变量，这里先使用长度为100的数组来实现

    if (n == 1)
    {
        result[0] = 1;
    }
    else if (n == 2)
    {
        result[0] = 1;
        result[1] = 1;
    }
    else
    {
        int *pointer = myfibonacci(n - 1);
        result[n - 1] = *(pointer + n - 3) + *(pointer + n - 2);
    }

    return result;
}