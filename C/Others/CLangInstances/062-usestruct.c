#include <stdio.h>

/*
使用结构体（struct）存储学生信息
*/

struct student
{
    char name[50];
    int roll;
    float marks;
} s;

int main()
{
    printf("输入信息:\n");

    printf("名字: ");
    scanf("%s", s.name);

    printf("编号: ");
    scanf("%d", &s.roll);

    printf("成绩: ");
    scanf("%f", &s.marks);

    printf("显示信息:\n");

    printf("名字: ");
    puts(s.name);

    printf("编号: %d\n", s.roll);

    printf("成绩: %.1f\n", s.marks);

    return 0;
}