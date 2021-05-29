#include <stdio.h>

int main()
{
    int i = 1024;
    int *pointer;    //这里的*表示的是这是一个指针变量，而不是普通的整型变量
                     //前面的int表示这个指针指向的内存块中存储的是一个整型，正确的变量类型，指针才知道变量由多宽（大）
    pointer = &i;

    printf("i:\t%d\n", i);
    printf("i address:\t%p\n", &i);       //&是获取变量地址的运算符
    printf("pointer:\t%p\n", pointer);    //%p，输出指针
    printf("pointer ref:\t%d\n", *pointer);  //这里的*是获取指针对应的值的运算符
}