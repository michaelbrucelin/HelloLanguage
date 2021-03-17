#include <stdio.h>
#include <stdarg.h>

//C语言中函数的可变参数，对应C#中的paras[]

double average(double v1, double v2, ...); /* Function prototype */

int main(void)
{
    double Val1 = 10.5, Val2 = 2.5;
    int num1 = 6, num2 = 5;
    long num3 = 12, num4 = 20;

    printf("Average = %lf\n", average(Val1, 3.5, Val2, 4.5, 0.0));
    printf("Average = %lf\n", average(1.0, 2.0, 0.0));
    printf("Average = %lf\n", average((double)num2, Val2, (double)num1, (double)num4, (double)num3, 0.0));
    return 0;
}

double average(double v1, double v2, ...)
{
    va_list parg; //指向可变参数列表的指针
    double sum = v1 + v2;
    double value = 0; //用于遍历可变参数列表中的每一个元素
    int count = 2;    //计数器，用于计算平均数

    va_start(parg, v2);                           //初始化可变参数列表，并将内部指针置于列表的头部
    while ((value = va_arg(parg, double)) != 0.0) //遍历可变参数的列表
    {
        sum += value;
        count++;
    }
    va_end(parg); //结束参数列表的遍历，使其指针指向NULL

    return sum / count;
}