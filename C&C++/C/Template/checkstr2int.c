#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[])
{
    if (strlen(argv[1]) == strlen(itoa(atoi(argv[1]))))
    {
        printf("%s is a number.\n", argv[1]);
    }
    else
    {
        printf("%s is not a number.\n", argv[1]);
    }

    return (0);
}

/*
没有编译通过，应该是由于itoa函数的原型不对，所以没有编译通过。

判断输入的字符串是否为一个整型数字（整型，而不是数字）
https://stackoverflow.com/questions/16644906/how-to-check-if-a-string-is-a-number

As atoi converts string to number skipping letters other than digits, if there was no other than digits its string length has to be the same as the original.
This solution is better than innumber() if the check is for integer.
*/