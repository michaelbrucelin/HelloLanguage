/*
题目：请输入星期几的第一个字母来判断一下是星期几，如果第一个字母一样，则继续判断第二个字母。

程序分析：用情况语句比较好，如果第一个字母一样，则判断用情况语句或if语句判断第二个字母。
*/

#include <stdio.h>

int main(void)
{
    char i, j;
    printf("请输入第一个字母:\n");
    scanf("%c", &i);
    getchar(); //scanf("%c",&j);的问题，第二次是读入的一个换行符，而不是输入的字符，因此需要加一个getchar() 吃掉换行符
    switch (i)
    {
    case 'm':
        printf("monday\n");
        break;
    case 'w':
        printf("wednesday\n");
        break;
    case 'f':
        printf("friday\n");
        break;
    case 't':
        printf("请输入下一个字母\n");
        scanf("%c", &j);
        if (j == 'u')
        {
            printf("tuesday\n");
            break;
        }
        if (j == 'h')
        {
            printf("thursday\n");
            break;
        }
    case 's':
        printf("请输入下一个字母\n");
        scanf("%c", &j);
        if (j == 'a')
        {
            printf("saturday\n");
            break;
        }
        if (j == 'u')
        {
            printf("sunday\n");
            break;
        }
    default:
        printf("error\n");
        break;
    }

    return (0);
}