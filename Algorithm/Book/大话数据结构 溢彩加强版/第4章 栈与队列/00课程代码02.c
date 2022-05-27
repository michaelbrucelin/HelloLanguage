#include <stdlib.h>

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0
#define MAXSIZE 20  /* 存储空间初始分配量 */
#define OVERFLOW -2 /* 堆溢出，add by michaelbrucelin */

typedef int SElemType; /* SElemType类型根据实际情况而定，这里假设为int */
typedef int Status;    /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

/* 两栈共享空间结构 */
typedef struct
{
    SElemType data[MAXSIZE];
    int top1; /* 栈1栈顶指针 */
    int top2; /* 栈2栈顶指针 */
} SqDoubleStack;

/* 插入元素e为新的栈顶元素 */
Status Push(SqDoubleStack *S, SElemType e, int stackNumber)
{
    if (S->top1 + 1 == S->top2) /* 栈已满，不能再push新元素了 */
        return ERROR;
    if (stackNumber == 1)       /* 栈1有元素进栈 */
        S->data[++S->top1] = e; /* 若是栈1则先top1+1后给数组元素赋值。 */
    else if (stackNumber == 2)  /* 栈2有元素进栈 */
        S->data[--S->top2] = e; /* 若是栈2则先top2-1后给数组元素赋值。 */
    return OK;
}

/* 若栈不空，则删除S的栈顶元素，用e返回其值，并返回OK；否则返回ERROR */
Status Pop(SqDoubleStack *S, SElemType *e, int stackNumber)
{
    if (stackNumber == 1)
    {
        if (S->top1 == -1)
            return ERROR;        /* 说明栈1已经是空栈，溢出 */
        *e = S->data[S->top1--]; /* 将栈1的栈顶元素出栈 */
    }
    else if (stackNumber == 2)
    {
        if (S->top2 == MAXSIZE)
            return ERROR;        /* 说明栈2已经是空栈，溢出 */
        *e = S->data[S->top2++]; /* 将栈2的栈顶元素出栈 */
    }
    return OK;
}
