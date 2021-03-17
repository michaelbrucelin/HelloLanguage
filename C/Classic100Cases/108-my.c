/*
题目：汉诺塔
        将盘子从X轴借助Y轴移到Z轴

程序分析：使用递归来实现，练习递归
*/

#include <stdio.h>

void hanoi(unsigned int level, char x, char y, char z);
int time = 0;

int main(void)
{
    unsigned int n;
    printf("please input the level:\n");
    scanf("%u", &n);
    //printf("======== %u ========\n", n);

    time = 0;
    hanoi(n, 'X', 'Y', 'Z');

    return (0);
}

//将level个盘子借助y，从x移到z
void hanoi(unsigned int level, char x, char y, char z)
{
    if (level == 0)
        printf("null\n");
    else if (level == 1)
        printf("%d:\t%c --> %c\n", ++time, x, z);
    else
    {
        hanoi(level - 1, x, z, y);
        printf("%d:\t%c --> %c\n", ++time, x, z);
        hanoi(level - 1, y, x, z);
    }
}