/* ˳��ջ�ṹ */
#include "my_macro.h"

#define MAXSIZE 20            // �洢�ռ��ʼ������

typedef int SElemType;        // SElemType���͸���ʵ������������������Ϊint
typedef struct
{
    SElemType data[MAXSIZE];
    int top;                  // ����ջ��ָ��
}SqStack;


/* ��ջ���� */
// ����Ԫ��eΪ�µ�ջ��Ԫ��
Status Push(SqStack* S, SElemType e)
{
    if (S->top == MAXSIZE - 1)  // ջ��
        return ERROR;

    S->top++;
    S->data[S->top] = e;

    return OK;
}


/* ��ջ���� */
// ��ջ���գ���ɾ��S��ջ��Ԫ�أ���e������ֵ��������OK�����򷵻�ERROR
Status Pop(SqStack* S, SElemType* e)
{
    if (S->top == -1)
        return ERROR;

    *e = S->data[S->top];  // ��Ҫɾ����ջ��Ԫ�ظ�ֵ��e
    S->top--;              // ջ��ָ���һ

    return OK;
}
