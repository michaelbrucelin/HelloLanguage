#include <stdio.h>

int main(void)
{
    unsigned int original = 0xABC; //1010 1011 1100
    unsigned int result = 0;       //0000 0000 0000
    unsigned int mask = 0xF;       //0000 0000 1111  1位的16进制正好是4位的2进制，所以掩码为1111

    printf("original = %X\n", original);

    //获取最右边的4位，即最右边的1位16进制，放到结果中
    //使用&与1111可以获取值，使用|与0000可以赋值
    result |= original & mask;

    //获取右边第2位16进制
    original >>= 4;            //original向右移4位，这样右边的第5-8位就变成了1-4位
    result <<= 4;              //result向左移4位，用来放新的值
    result |= original & mask; //将新的值放到result的最右边4位

    //获取右边第3位16进制
    original >>= 4;
    result <<= 4;
    result |= original & mask;
    printf("result   = %X\n", result);

    return 0;
}