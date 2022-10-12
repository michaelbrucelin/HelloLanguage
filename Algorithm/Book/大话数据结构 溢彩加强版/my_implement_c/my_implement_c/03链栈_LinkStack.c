#include <malloc.h>

/* 链栈结构 */
typedef int SElemType;        // SElemType类型根据实际情况而定，这里假设为int
typedef struct StackNode
{
	SElemType data;
	struct StackNode* next;
}StackNode, * LinkStackPtr;

typedef struct
{
	LinkStackPtr top;
	int count;
}LinkStack;

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0

typedef int Status;           // Status是函数的类型，其值是函数结果的状态代码，如OK等


/* 进栈操作 */
// 插入元素e为新的栈顶元素
Status Push(LinkStack* S, SElemType e)
{
	LinkStackPtr s = (LinkStackPtr)malloc(sizeof(StackNode));
	if (s == NULL)
	{
		printf("Memory allocation failed");
		return ERROR;
	}

	s->data = e;
	s->next = S->top;  // 把当前的栈顶元素赋值给新结点的直接后继
	S->top = s;        // 将新的结点s赋值给栈顶指针
	S->count++;

	return OK;
}


/* 出栈操作 */
// 若栈S为空栈，则返回TRUE，否则返回FALSE
Status StackEmpty(LinkStack S)
{
	if (S.count == 0)
		return TRUE;
	else
		return FALSE;
}

// 若栈不空，则删除S的栈顶元素，用e返回其值，并返回OK；否则返回ERROR
Status Pop(LinkStack* S, SElemType* e)
{
	LinkStackPtr p;
	if (StackEmpty(*S))
		return ERROR;

	*e = S->top->data;
	p = S->top;
	S->top = S->top->next;
	free(p);
	S->count--;

	return OK;
}
