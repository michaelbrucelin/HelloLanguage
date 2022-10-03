#include <stdlib.h>

/* ���Ա�ĵ�����洢�ṹ */
typedef int ElemType;           // ElemType���͸��ݾ����������������Ϊint
typedef struct Node {
	ElemType data;
	struct Node* next;
}Node;
typedef struct Node* LinkList;  // ����LinkList

#define OK 1
#define ERROR 0

typedef int Status;          // Status�Ǻ��������ͣ���ֵ�Ǻ��������״̬���룬��OK��


/* ��ȡԪ�ز��� */
// ��ʼ��������ʽ���Ա�L�Ѵ��ڣ�1��i��ListLength(L)
// �����������e����L�еڸ�Ԫ�ص�ֵ��ע��i��ָλ�ã���1��λ�õ������Ǵ�0��ʼ
Status GetElem(LinkList L, int i, ElemType* e)
{
	int j;
	LinkList p;         // ����һ���p
	p = L->next;        // ��pָ������L�ĵ�һ�����
	j = 1;              // jΪ������
	while (p && j < i)  // p��Ϊ�ջ��߼�����j��û�е���iʱ��ѭ������
	{
		p = p->next;    // ��pָ����һ�����
		++j;
	}

	if (!p || j > i)    // j > i ��Ϊ�˷�ֹ i<=0 ��
		return ERROR;   // ��i��Ԫ�ز�����
	*e = p->data;       // ȡ��i��Ԫ�ص�����

	return OK;
}


/* ������� */
// ��ʼ��������ʽ���Ա�L�Ѵ���,1��i��ListLength(L)
// �����������L�е�i��λ��֮ǰ�����µ�����Ԫ��e��L�ĳ��ȼ�1
Status ListInsert(LinkList* L, int i, ElemType e)
{
	int j;
	LinkList p, s;
	p = *L;
	j = 1;
	while (p && j < i)                   // Ѱ�ҵ�i�����
	{
		p = p->next;
		++j;
	}

	if (!p || j > i)
		return ERROR;                    // ��i��Ԫ�ز�����

	s = (LinkList)malloc(sizeof(Node));  // �����½��(C���Ա�׼����)
	if (s == NULL)
	{
		printf("Memory allocation failed");
		return ERROR;
	}
	s->data = e;
	s->next = p->next;                   // ��p�ĺ�̽�㸳ֵ��s�ĺ��
	p->next = s;                         // ��s��ֵ��p�ĺ��

	return OK;
}


/* ɾ������ */
// ��ʼ��������ʽ���Ա�L�Ѵ��ڣ�1��i��ListLength(L)
// ���������ɾ��L�ĵ�i������Ԫ�أ�����e������ֵ��L�ĳ��ȼ�1
Status ListDelete(LinkList* L, int i, ElemType* e)
{
	int j;
	LinkList p, q;
	p = *L;
	j = 1;
	while (p->next && j < i)  // ����Ѱ�ҵ�i��Ԫ��
	{
		p = p->next;
		++j;
	}

	if (!(p->next) || j > i)
		return ERROR;         // ��i��Ԫ�ز�����

	q = p->next;
	p->next = q->next;        // ��q�ĺ�̸�ֵ��p�ĺ��
	*e = q->data;             // ��q����е����ݸ�e
	free(q);                  // ��ϵͳ���մ˽�㣬�ͷ��ڴ�

	return OK;
}


/* ������������� */
// �������n��Ԫ�ص�ֵ����������ͷ���ĵ������Ա�L��ͷ�巨��
void CreateListHead(LinkList* L, int n)
{
	LinkList p;
	int i;
	srand(time(0));                          // ��ʼ�����������
	*L = (LinkList)malloc(sizeof(Node));
	if (*L == NULL)
	{
		printf("Memory allocation failed");
		return ERROR;
	}
	(*L)->next = NULL;                       // �Ƚ���һ����ͷ���ĵ�����
	for (i = 0; i < n; i++)
	{
		p = (LinkList)malloc(sizeof(Node));  // �����½��
		if (p == NULL)
		{
			printf("Memory allocation failed");
			return ERROR;
		}
		p->data = rand() % 100 + 1;          // �������100���ڵ�����
		p->next = (*L)->next;
		(*L)->next = p;                      // ���뵽��ͷ
	}
}

// �������n��Ԫ�ص�ֵ����������ͷ���ĵ������Ա�L��β�巨��
void CreateListTail(LinkList* L, int n)
{
	LinkList p, r;
	int i;
	srand(time(0));                       // ��ʼ�����������
	*L = (LinkList)malloc(sizeof(Node));  // LΪ�������Ա�
	if (*L == NULL)
	{
		printf("Memory allocation failed");
		return ERROR;
	}
	r = *L;                               // rΪָ��β���Ľ��
	for (i = 0; i < n; i++)
	{
		p = (Node*)malloc(sizeof(Node));  // �����½��
		if (p == NULL)
		{
			printf("Memory allocation failed");
			return ERROR;
		}
		p->data = rand() % 100 + 1;       // �������100���ڵ�����
		r->next = p;                      // ����β�ն˽���ָ��ָ���½��
		r = p;                            // ����ǰ���½�㶨��Ϊ��β�ն˽��
	}
	r->next = NULL;                       // ��ʾ��ǰ�������
}


/* �����������ɾ�� */
// ��ʼ��������ʽ���Ա�L�Ѵ��ڡ������������L����Ϊ�ձ�
Status ClearList(LinkList* L)
{
	LinkList p, q;
	p = (*L)->next;     // pָ���һ�����
	while (p)           // û����β
	{
		q = p->next;
		free(p);
		p = q;
	}
	(*L)->next = NULL;  // ͷ���ָ����Ϊ��

	return OK;
}
