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


/* ɾ������ */
// ��ʼ��������ʽ���Ա�L�Ѵ��ڣ�1��i��ListLength(L)
// ���������ɾ��L�ĵ�i������Ԫ�أ�����e������ֵ��L�ĳ��ȼ�1
