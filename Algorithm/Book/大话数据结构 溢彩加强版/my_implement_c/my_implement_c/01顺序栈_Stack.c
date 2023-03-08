/* 顺序栈结构 */
#include "my_macro.h"

#define MAXSIZE 20            // 存储空间初始分配量

typedef int SElemType;        // SElemType类型根据实际情况而定，这里假设为int
typedef struct
{
    SElemType data[MAXSIZE];
    int top;                  // 用于栈顶指针
}SqStack;


/* 进栈操作 */
// 插入元素e为新的栈顶元素
Status Push(SqStack* S, SElemType e)
{
    if (S->top == MAXSIZE - 1)  // 栈满
        return ERROR;

    S->top++;
    S->data[S->top] = e;

    return OK;
}


/* 出栈操作 */
// 若栈不空，则删除S的栈顶元素，用e返回其值，并返回OK；否则返回ERROR
Status Pop(SqStack* S, SElemType* e)
{
    if (S->top == -1)
        return ERROR;

    *e = S->data[S->top];  // 将要删除的栈顶元素赋值给e
    S->top--;              // 栈顶指针减一

    return OK;
}
