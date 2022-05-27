#include <stdlib.h>

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0
#define MAXSIZE 20  /* 存储空间初始分配量 */
#define OVERFLOW -2 /* 堆溢出，add by michaelbrucelin */

typedef int SElemType; /* SElemType类型根据实际情况而定，这里假设为int */
typedef int Status;    /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

/* 顺序栈结构 */
typedef struct
{
    SElemType data[MAXSIZE];
    int top; /* 用于栈顶指针 */
} SqStack;

/* 插入元素e为新的栈顶元素 */
Status Push(SqStack *S, SElemType e)
{
    if (S->top == MAXSIZE - 1) /* 栈满 */
    {
        return ERROR;
    }
    S->top++;            /* 栈顶指针增加一 */
    S->data[S->top] = e; /* 将新插入元素赋值给栈顶空间 */
    return OK;
}

/* 若栈不空，则删除S的栈顶元素，用e返回其值，并返回OK；否则返回ERROR */
Status Pop(SqStack *S, SElemType *e)
{
    if (S->top == -1)
        return ERROR;
    *e = S->data[S->top]; /* 将要删除的栈顶元素赋值给e */
    S->top--;             /* 栈顶指针减一 */
    return OK;
}
