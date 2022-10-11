#include <malloc.h>

/* 队列的链表结构 */
typedef int QElemType;     // QElemType类型根据实际情况而定，这里假设为int
typedef struct QNode       // 结点结构
{
	QElemType data;
	struct QNode* next;
}QNode, * QueuePtr;

typedef struct             // 队列的链表结构
{
	QueuePtr front, rear;  // 队头、队尾指针
}LinkQueue;

#define OK 1
#define ERROR 0

typedef int Status;        // Status是函数的类型，其值是函数结果的状态代码，如OK等

#define OVERFLOW -2        // 堆溢出

/*入队操作*/
// 插入元素e为Q的新的队尾元素
Status EnQueue(LinkQueue* Q, QElemType e)
{
	QueuePtr s = (QueuePtr)malloc(sizeof(QNode));
	// if (!s) exit(OVERFLOW);
	if (s == NULL)      // 存储分配失败
	{
		printf("Memory allocation failed");
		return ERROR;
	}

	s->data = e;
	s->next = NULL;
	Q->rear->next = s;  // 把拥有元素e的新结点s赋值给原队尾结点的后继
	Q->rear = s;        // 把当前的s设置为队尾结点，rear指向s

	return OK;
}


/*出队操作*/
// 若队列不空,删除Q的队头元素,用e返回其值,并返回OK,否则返回ERROR
Status DeQueue(LinkQueue* Q, QElemType* e)
{
	QueuePtr p;
	if (Q->front == Q->rear)
		return ERROR;

	p = Q->front->next;        // 将欲删除的队头结点暂存给p
	*e = p->data;              // 将欲删除的队头结点的值赋值给e
	Q->front->next = p->next;  // 将原队头结点的后继p->next赋值给头结点后继
	if (Q->rear == p)          // 若队头就是队尾，则删除后将rear指向头结点
		Q->rear = Q->front;
	free(p);

	return OK;
}
