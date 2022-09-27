#include <stdlib.h>

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0
#define MAXSIZE 20  /* 存储空间初始分配量 */
#define OVERFLOW -2 /* 堆溢出，add by michaelbrucelin */

typedef int SElemType; /* SElemType类型根据实际情况而定，这里假设为int */
typedef int Status;    /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

typedef int QElemType; /* QElemType类型根据实际情况而定，这里假设为int */

typedef struct QNode /* 结点结构 */
{
    QElemType data;
    struct QNode *next;
} QNode, *QueuePtr;

typedef struct /* 队列的链表结构 */
{
    QueuePtr front, rear; /* 队头、队尾指针 */
} LinkQueue;

/* 插入元素e为Q的新的队尾元素 */
Status EnQueue(LinkQueue *Q, QElemType e)
{
    QueuePtr s = (QueuePtr)malloc(sizeof(QNode));
    if (!s) /* 存储分配失败 */
        exit(OVERFLOW);
    s->data = e;
    s->next = NULL;
    Q->rear->next = s; /* 把拥有元素e的新结点s赋值给原队尾结点的后继，见图中① */
    Q->rear = s;       /* 把当前的s设置为队尾结点，rear指向s，见图中② */
    return OK;
}

/* 若队列不空,删除Q的队头元素,用e返回其值,并返回OK,否则返回ERROR */
Status DeQueue(LinkQueue *Q, QElemType *e)
{
    QueuePtr p;
    if (Q->front == Q->rear)
        return ERROR;
    p = Q->front->next;       /* 将欲删除的队头结点暂存给p，见图中① */
    *e = p->data;             /* 将欲删除的队头结点的值赋值给e */
    Q->front->next = p->next; /* 将原队头结点的后继p->next赋值给头结点后继，见图中② */
    if (Q->rear == p)         /* 若队头就是队尾，则删除后将rear指向头结点，见图中③ */
        Q->rear = Q->front;
    free(p);
    return OK;
}
