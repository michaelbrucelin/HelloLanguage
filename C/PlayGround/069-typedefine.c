#include <stdio.h>

//typedef就是给现有的类型定义一个别名

typedef struct //定义一个结构类型
{
    int year;
    int month;
    int day;
} DATE;
typedef int NUM100[100]; //定义一个特定的数组类型
typedef char *PC;        //定义一个字符指针类型
typedef void (*PFUN)();  //定义一个函数指针类型

void fun();
int main(void)
{
    DATE date1;
    date1.year = 2020;
    date1.month = 11;
    date1.day = 13;

    printf("%d %d %d\n\n", date1.year, date1.month, date1.day);

    NUM100 num = {0};
    printf("%d\n\n", sizeof(num));

    PC p1;
    p1 = "I Love 56887";
    printf("%s\n\n", p1);

    PFUN p2;
    p2 = fun; //函数和数组比较像，名称的值就是其地址，所以这里使用fun与使用&fun是一样的
    (p2)();

    printf("\n");

    return (0);
}

void fun()
{
    printf("I Love 56887");
}