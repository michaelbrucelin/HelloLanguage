#include <malloc.h>

/* ���е�����ṹ */
typedef int QElemType;     // QElemType���͸���ʵ������������������Ϊint
typedef struct QNode       // ���ṹ
{
	QElemType data;
	struct QNode* next;
}QNode, * QueuePtr;

typedef struct             // ���е�����ṹ
{
	QueuePtr front, rear;  // ��ͷ����βָ��
}LinkQueue;

#define OK 1
#define ERROR 0

typedef int Status;        // Status�Ǻ��������ͣ���ֵ�Ǻ��������״̬���룬��OK��

#define OVERFLOW -2        // �����

/*��Ӳ���*/
// ����Ԫ��eΪQ���µĶ�βԪ��
Status EnQueue(LinkQueue* Q, QElemType e)
{
	QueuePtr s = (QueuePtr)malloc(sizeof(QNode));
	// if (!s) exit(OVERFLOW);
	if (s == NULL)      // �洢����ʧ��
	{
		printf("Memory allocation failed");
		return ERROR;
	}

	s->data = e;
	s->next = NULL;
	Q->rear->next = s;  // ��ӵ��Ԫ��e���½��s��ֵ��ԭ��β���ĺ��
	Q->rear = s;        // �ѵ�ǰ��s����Ϊ��β��㣬rearָ��s

	return OK;
}


/*���Ӳ���*/
// �����в���,ɾ��Q�Ķ�ͷԪ��,��e������ֵ,������OK,���򷵻�ERROR
Status DeQueue(LinkQueue* Q, QElemType* e)
{
	QueuePtr p;
	if (Q->front == Q->rear)
		return ERROR;

	p = Q->front->next;        // ����ɾ���Ķ�ͷ����ݴ��p
	*e = p->data;              // ����ɾ���Ķ�ͷ����ֵ��ֵ��e
	Q->front->next = p->next;  // ��ԭ��ͷ���ĺ��p->next��ֵ��ͷ�����
	if (Q->rear == p)          // ����ͷ���Ƕ�β����ɾ����rearָ��ͷ���
		Q->rear = Q->front;
	free(p);

	return OK;
}
