#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    int i;
    int sum = 0;
    char ch;

    printf("输入多个数字，用空格间隔开，例如：11 22 33 44： ");
    while (scanf("%d", &i) == 1)
    {
        sum += i;
        while ((ch = getchar()) == ' ') //屏蔽空格
            ;
        if (ch == '\n')
            break;

        ungetc(ch, stdin); //最后从while中跳出后，(ch = getchar()) ！= ' '，即读取到了一个数字，将读取到的数字还给stdin流
    }

    printf("C结果为：%d\n", sum);

    return (0);
}