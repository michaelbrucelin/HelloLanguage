#include <stdio.h>

/*
通过位运算来实现大小写转换
思路：
大写字母的ASCII码是65~90，小写字母的ASCII码是97~112，可以发现对应的大小写字母相差32（100000）
也就是说，只要改变字母的ASCII码的第6位，就可以实现大小写的转换
*/

int main(void)
{
    char ch = 0, temp = 0; //temp是为了吃掉回车的，应该会有专门的函数做这个，这里就这么解决了

    printf("please input a letter:\n");
    ch = getchar();
    temp = getchar();

    while (!((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')))
    {
        printf("input error, please input a letter:\n");
        ch = getchar();
        temp = getchar();
    }

    if (ch & 32)
        ch = ch & 223; //使第六位置为0，变大写，223=255-32
    else
        ch = ch | 255; //使第六位置为1，变小写

    //输出
    putchar(ch);
    ch = getchar();
    putchar(ch);
}