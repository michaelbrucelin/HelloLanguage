/* ��ջ����ռ�ṹ */
#include "my_macro.h"

#define MAXSIZE 20            // �洢�ռ��ʼ������

typedef int SElemType;        // SElemType���͸���ʵ������������������Ϊint
typedef struct
{
    SElemType data[MAXSIZE];
    int top1;                 // ջ1ջ��ָ��
    int top2;                 // ջ2ջ��ָ��
}SqDoubleStack;


/* ��ջ���� */
// ����Ԫ��eΪ�µ�ջ��Ԫ��
Status Push(SqDoubleStack* S, SElemType e, int stackNumber)
{
    if (S->top1 + 1 == S->top2)  // ջ������������push��Ԫ����
        return ERROR;
    if (stackNumber == 1)        // ջ1��Ԫ�ؽ�ջ
        S->data[++S->top1] = e;  // ����ջ1����top1+1�������Ԫ�ظ�ֵ
    else if (stackNumber == 2)   // ջ2��Ԫ�ؽ�ջ
        S->data[--S->top2] = e;  // ����ջ2����top2-1�������Ԫ�ظ�ֵ

    return OK;
}


/* ��ջ���� */
// ��ջ���գ���ɾ��S��ջ��Ԫ�أ���e������ֵ��������OK�����򷵻�ERROR
Status Pop(SqDoubleStack* S, SElemType* e, int stackNumber)
{
    if (stackNumber == 1)
    {
        if (S->top1 == -1)
            return ERROR;         // ˵��ջ1�Ѿ��ǿ�ջ�����
        *e = S->data[S->top1--];  // ��ջ1��ջ��Ԫ�س�ջ
    }
    else if (stackNumber == 2)
    {
        if (S->top2 == MAXSIZE)
            return ERROR;         // ˵��ջ2�Ѿ��ǿ�ջ�����
        *e = S->data[S->top2++];  // ��ջ2��ջ��Ԫ�س�ջ
    }

    return OK;
}
