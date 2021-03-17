/*
题目：二进制转十进制

程序分析：使用栈来实现，主要是做一个栈练练手。
*/

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define STACK_INIT_SIZE 10 //栈的初始大小
#define STACK_INCREMENT 10 //栈的容量不足时，每次扩容的数量，有些实现是直接容量翻倍，或是更复杂的控制

typedef char ElemType;
typedef struct
{
    ElemType *base; //栈底的地址
    ElemType *top;  //栈顶的地址
    int stackSize;  //栈的总容量
} MyStack;

//栈的初始化
void InitStack(MyStack *s)
{
    s->base = (ElemType *)malloc(STACK_INIT_SIZE * sizeof(ElemType));
    if (!s->base)
        exit(0);

    s->top = s->base;
    s->stackSize = STACK_INIT_SIZE;
}

//压栈
void Push(MyStack *s, ElemType e)
{
    if (s->top - s->base >= s->stackSize) //如果栈已经满了
    {
        s->base = (ElemType *)realloc(s->base, (s->stackSize + STACK_INCREMENT) * sizeof(ElemType));
        if (!s->base)
            exit(0);

        s->stackSize += STACK_INCREMENT;
    }
    *(s->top) = e;
    s->top++;
}

//弹栈
void Pop(MyStack *s, ElemType *e)
{
    if (s->top == s->base) //如果已经在栈底
        return;

    *e = *(--(s->top));
}

//当前栈内元素数量
int StackLen(MyStack s)
{
    return (s.top - s.base);
}

int main(void)
{
    ElemType c;
    MyStack s;
    int len, i, sum = 0;

    InitStack(&s);

    printf("请输入一个二进制数，以#结束！\n");
    scanf("%c", &c);
    while (c != '#')
    {
        Push(&s, c);
        scanf("%c", &c);
    }
    getchar(); //将最后键入的回车键接收，也可以使用清空输入缓冲区的函数，不过那样消耗较多，没必要

    len = StackLen(s);
    printf("栈当前容量为：%d\n", len);

    //二进制转十进制，弹栈
    for (i = 0; i < len; i++)
    {
        Pop(&s, &c);
        sum += (c - 48) * pow(2, i); //0的ASCII码为48
    }
    printf("转化为十进制的结果为：%d\n", sum);

    return (0);
}