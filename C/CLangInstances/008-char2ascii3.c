#include <stdio.h>
#define MAX_ASCII 127

int main()
{
    char num, enter;
    int temp = 1;

    for (; temp > 0;)
    {
        printf("----------------------------\n");
        printf("|**      开始            **|\n");
        printf("|**ASCII  转  字符  按:1 **|\n");
        printf("|**字符   转  ASCII 按:2 **|\n");
        printf("|**      结束       按:0 **|\n");
        printf("----------------------------\n");
        scanf("%d", &temp);
        if (temp == 1)
        {
            printf("请输入数值小于 %d 的任意字符：", MAX_ASCII);
            scanf("%d", &num);
            printf("ASCII为 %d, 对应的字符为 %c \n", num, num);
        }
        if (temp == 2)
        {
            printf("输入一个字符: \n");
            scanf("%c", &enter); //回车键也算字符,所以这里使用其他变量替之.
            scanf("%c", &num);
            printf("     %c 的 ASCII 为 %d    \n", num, num);
        }
    }

    return 0;
}