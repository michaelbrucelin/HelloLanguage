/* 循环队列的顺序存储结构 */
#define MAXSIZE 20            // 存储空间初始分配量

typedef int QElemType;        // QElemType类型根据实际情况而定，这里假设为int
typedef struct
{
	QElemType data[MAXSIZE];
	int front;                // 尾指针，若队列不空，指向队列尾元素的下一个位置
	int rear;                 // 头指针
}SqQueue;

#define OK 1
#define ERROR 0

typedef int Status;           // Status是函数的类型，其值是函数结果的状态代码，如OK等


/* 初始化操作 */
// 初始化一个空队列Q
Status InitQueue(SqQueue* Q)
{
	Q->front = 0;
	Q->rear = 0;
	return OK;
}


/* 获取队列的长度 */
// 返回Q的元素个数，也就是队列的当前长度
int QueueLength(SqQueue Q)
{
	return (Q.rear - Q.front + MAXSIZE) % MAXSIZE;
}


/* 入队操作 */
// 若队列未满，则插入元素e为Q新的队尾元素
Status EnQueue(SqQueue* Q, QElemType e)
{
	if ((Q->rear + 1) % MAXSIZE == Q->front)  // 队列满的判断
		return ERROR;
	Q->data[Q->rear] = e;                     // 将元素e赋值给队尾
	Q->rear = (Q->rear + 1) % MAXSIZE;        // rear指针向后移一位置，若到最后则转到数组头部

	return OK;
}


/* 出队操作 */
// 若队列不空，则删除Q中队头元素，用e返回其值
Status DeQueue(SqQueue* Q, QElemType* e)
{
	if (Q->front == Q->rear)              // 队列空的判断
		return ERROR;
	*e = Q->data[Q->front];               // 将队头元素赋值给e
	Q->front = (Q->front + 1) % MAXSIZE;  // front指针向后移一位置，若到最后则转到数组头部

	return OK;
}
