/*
题目：求一个3*3矩阵对角线元素之和

程序分析：利用双重for循环控制输入二维数组，再将a[i][i]累加后输出。
*/

#include <stdio.h>

#define N 3

int main(void)
{
    int i, j, a[N][N], sum = 0;
    printf("请输入矩阵(3*3)：\n");
    for (i = 0; i < N; i++)
        for (j = 0; j < N; j++)
            scanf("%d", &a[i][j]);
    for (i = 0; i < N; i++)
        sum += a[i][i];
    printf("对角线之和为：%d\n", sum);

    return (0);
}