#include <stdlib.h>

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0
#define MAXSIZE 20  /* 存储空间初始分配量 */
#define OVERFLOW -2 /* 堆溢出，add by michaelbrucelin */

typedef int SElemType; /* SElemType类型根据实际情况而定，这里假设为int */
typedef int Status;    /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

/* 链栈结构 */
typedef struct StackNode
{
    SElemType data;
    struct StackNode *next;
} StackNode, *LinkStackPtr;

typedef struct
{
    LinkStackPtr top;
    int count;
} LinkStack;

/* 插入元素e为新的栈顶元素 */
Status Push(LinkStack *S, SElemType e)
{
    LinkStackPtr s = (LinkStackPtr)malloc(sizeof(StackNode));
    s->data = e;
    s->next = S->top; /* 把当前的栈顶元素赋值给新结点的直接后继，见图中① */
    S->top = s;       /* 将新的结点s赋值给栈顶指针，见图中② */
    S->count++;
    return OK;
}

/* 若栈不空，则删除S的栈顶元素，用e返回其值，并返回OK；否则返回ERROR */
Status Pop(LinkStack *S, SElemType *e)
{
    LinkStackPtr p;
    if (StackEmpty(*S))
        return ERROR;
    *e = S->top->data;
    p = S->top;            /* 将栈顶结点赋值给p，见图中③ */
    S->top = S->top->next; /* 使得栈顶指针下移一位，指向后一结点，见图中④ */
    free(p);               /* 释放结点p */
    S->count--;
    return OK;
}
