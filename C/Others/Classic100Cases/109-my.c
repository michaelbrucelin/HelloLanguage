/*
题目：八皇后问题

程序分析：使用递归来实现，练习递归（回溯算法更好，这里只是为了练习递归）
*/

#include <stdio.h>

#define N 8

int IfNotDanger(int row, int j, int (*chess)[8]);
void EightQueen(int row, int n, int (*chess)[8]);

int count = 0;

int main(void)
{
    int chess[N][N], i, j;

    for (i = 0; i < N; i++)
    {
        for (j = 0; j < N; j++)
        {
            chess[i][j] = 0;
        }
    }

    EightQueen(0, N, chess);

    printf("总共有 %d 种解决方法!\n\n", count);

    return (0);
}

// 参数row: 表示起始行
// 参数n:   表示列数
// 参数(*chess)[N]: 表示指向棋盘每一行的指针
void EightQueen(int row, int n, int (*chess)[N])
{
    int chess2[N][N], i, j;

    for (i = 0; i < N; i++)
    {
        for (j = 0; j < N; j++)
        {
            chess2[i][j] = chess[i][j];
        }
    }

    if (N == row)
    {
        printf("第 %d 种\n", count + 1);
        for (i = 0; i < N; i++)
        {
            for (j = 0; j < N; j++)
            {
                printf("%c ", *(*(chess2 + i) + j) == 0 ? 'o' : '#');
            }
            printf("\n");
        }
        printf("\n");
        count++;
    }
    else
    {
        for (j = 0; j < n; j++)
        {
            if (IfNotDanger(row, j, chess)) // 判断是否危险
            {
                for (i = 0; i < N; i++)
                {
                    *(*(chess2 + row) + i) = 0;
                }

                *(*(chess2 + row) + j) = 1;

                EightQueen(row + 1, n, chess2);
            }
        }
    }
}

int IfNotDanger(int row, int j, int (*chess)[N])
{
    int i, k, flag1 = 0, flag2 = 0, flag3 = 0, flag4 = 0, flag5 = 0;

    // 判断列方向
    for (i = 0; i < N; i++)
    {
        if (*(*(chess + i) + j) != 0)
        {
            flag1 = 1;
            break;
        }
    }

    // 判断左上方
    for (i = row, k = j; i >= 0 && k >= 0; i--, k--)
    {
        if (*(*(chess + i) + k) != 0)
        {
            flag2 = 1;
            break;
        }
    }

    // 判断右下方
    for (i = row, k = j; i < N && k < N; i++, k++)
    {
        if (*(*(chess + i) + k) != 0)
        {
            flag3 = 1;
            break;
        }
    }

    // 判断右上方
    for (i = row, k = j; i >= 0 && k < N; i--, k++)
    {
        if (*(*(chess + i) + k) != 0)
        {
            flag4 = 1;
            break;
        }
    }

    // 判断左下方
    for (i = row, k = j; i < N && k >= 0; i++, k--)
    {
        if (*(*(chess + i) + k) != 0)
        {
            flag5 = 1;
            break;
        }
    }

    if (flag1 || flag2 || flag3 || flag4 || flag5)
        return 0;
    else
        return 1;
}