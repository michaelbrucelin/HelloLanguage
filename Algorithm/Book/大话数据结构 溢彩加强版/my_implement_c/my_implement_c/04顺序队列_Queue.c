/* ѭ�����е�˳��洢�ṹ */
#define MAXSIZE 20            // �洢�ռ��ʼ������

typedef int QElemType;        // QElemType���͸���ʵ������������������Ϊint
typedef struct
{
	QElemType data[MAXSIZE];
	int front;                // βָ�룬�����в��գ�ָ�����βԪ�ص���һ��λ��
	int rear;                 // ͷָ��
}SqQueue;

#define OK 1
#define ERROR 0

typedef int Status;           // Status�Ǻ��������ͣ���ֵ�Ǻ��������״̬���룬��OK��


/* ��ʼ������ */
// ��ʼ��һ���ն���Q
Status InitQueue(SqQueue* Q)
{
	Q->front = 0;
	Q->rear = 0;
	return OK;
}


/* ��ȡ���еĳ��� */
// ����Q��Ԫ�ظ�����Ҳ���Ƕ��еĵ�ǰ����
int QueueLength(SqQueue Q)
{
	return (Q.rear - Q.front + MAXSIZE) % MAXSIZE;
}


/* ��Ӳ��� */
// ������δ���������Ԫ��eΪQ�µĶ�βԪ��
Status EnQueue(SqQueue* Q, QElemType e)
{
	if ((Q->rear + 1) % MAXSIZE == Q->front)  // ���������ж�
		return ERROR;
	Q->data[Q->rear] = e;                     // ��Ԫ��e��ֵ����β
	Q->rear = (Q->rear + 1) % MAXSIZE;        // rearָ�������һλ�ã����������ת������ͷ��

	return OK;
}


/* ���Ӳ��� */
// �����в��գ���ɾ��Q�ж�ͷԪ�أ���e������ֵ
Status DeQueue(SqQueue* Q, QElemType* e)
{
	if (Q->front == Q->rear)              // ���пյ��ж�
		return ERROR;
	*e = Q->data[Q->front];               // ����ͷԪ�ظ�ֵ��e
	Q->front = (Q->front + 1) % MAXSIZE;  // frontָ�������һλ�ã����������ת������ͷ��

	return OK;
}
