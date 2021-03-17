/*
题目：时间函数举例1

程序分析：无。
*/

#include <stdio.h>
#include <time.h>

int main(void)
{
    time_t rawtime;
    struct tm *timeinfo;

    time(&rawtime);
    timeinfo = localtime(&rawtime);
    printf("当前本地时间为: %s", asctime(timeinfo));

    return (0);
}