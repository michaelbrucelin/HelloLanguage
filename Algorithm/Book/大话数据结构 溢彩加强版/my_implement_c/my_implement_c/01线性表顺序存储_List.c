/* ���Ա��˳��洢�ṹ */
#include "my_macro.h"

#define MAXSIZE 20           // �洢�ռ��ʼ������

typedef int ElemType;        // ElemType���͸��ݾ����������������Ϊint
typedef struct
{
	ElemType data[MAXSIZE];  // ���飬�洢����Ԫ��
	int length;              // ���Ա�ǰ����
}SqList;


/* ��ȡԪ�ز��� */
// ��ʼ������˳�����Ա�L�Ѵ��ڣ�1��i��ListLength(L)
// �����������e����L�еڸ�Ԫ�ص�ֵ��ע��i��ָλ�ã���1��λ�õ������Ǵ�0��ʼ
Status GetElem(SqList L, int i, ElemType* e)
{
	if (L.length == 0 || i < 1 || i > L.length)
		return ERROR;
	*e = L.data[i - 1];

	return OK;
}


/* ������� */
// ��ʼ������˳�����Ա�L�Ѵ���,1��i��ListLength(L)
// �����������L�е�i��λ��֮ǰ�����µ�����Ԫ��e��L�ĳ��ȼ�1
Status ListInsert(SqList* L, int i, ElemType e)
{
	int k;
	if (L->length == MAXSIZE)                 // ˳�����Ա��Ѿ���
		return ERROR;
	if (i < 1 || i > L->length + 1)           // ��i�ȵ�һλ��С���߱����һλ�ú�һλ�û�Ҫ��ʱ
		return ERROR;

	if (i <= L->length)                       // ����������λ�ò��ڱ�β
	{
		for (k = L->length - 1; k >= i; k--)  // ��Ҫ����λ��֮�������Ԫ������ƶ�һλ
			L->data[k + 1] = L->data[k];
	}
	L->data[i - 1] = e;                       // ����Ԫ�ز���
	L->length++;

	return OK;
}


/* ɾ������ */
// ��ʼ������˳�����Ա�L�Ѵ��ڣ�1��i��ListLength(L)
// ���������ɾ��L�ĵ�i������Ԫ�أ�����e������ֵ��L�ĳ��ȼ�1
Status ListDelete(SqList* L, int i, ElemType* e)
{
	int k;
	if (L->length == 0)
		return ERROR;
	if (i < 1 || i > L->length)
		return ERROR;

	*e = L->data[i - 1];
	if (i < L->length)
	{
		for (k = i; k < L->length; k++)
			L->data[k - 1] = L->data[k];
	}
	L->length--;

	return OK;
}