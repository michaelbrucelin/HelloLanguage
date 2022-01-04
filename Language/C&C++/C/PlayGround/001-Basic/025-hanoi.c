/*
汉诺塔的程序实现，使用迭代
*/

#include <stdio.h>

int main()
{
    int level;

    printf("input the level\n");
    scanf("%d", &level);

    //声明函数，level是盘子的层数，借助B从A移到C
    void myhanoi(int level, char A, char B, char C);

    myhanoi(level, 'A', 'B', 'C');
}

void myhanoi(int level, char A, char B, char C)
{
    void mymove(char x, char y);
    //如果只有一个盘子，直接从A移到C
    if (level == 1)
    {
        mymove(A, C);
    }
    //如果不止一个盘子，递归
    else
    {
        /*
        思路，
        只要能将level-1个盘子先移到B，就可以将第level个盘子直接移到C，
        那么接下来只要将B的level-1个盘子借助A移到C即可
        */
        //将level-1个盘子从A借助C移到B
        myhanoi(level - 1, A, C, B);
        //将第n个盘子移到C
        mymove(A, C);
        //将level-1个盘子从B借助A移到C
        myhanoi(level - 1, B, A, C);
    }
}

void mymove(char x, char y)
{
    //静态变量，记录移动的次数
    static int times = 0;
    printf("%d\t%c——>%c\n", ++times, x, y);
}