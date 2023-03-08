#include <malloc.h>
#include "my_macro.h"

/* ��ջ�ṹ */
typedef int SElemType;        // SElemType���͸���ʵ������������������Ϊint
typedef struct StackNode
{
    SElemType data;
    struct StackNode* next;
}StackNode, * LinkStackPtr;

typedef struct
{
    LinkStackPtr top;
    int count;
}LinkStack;


/* ��ջ���� */
// ����Ԫ��eΪ�µ�ջ��Ԫ��
Status Push(LinkStack* S, SElemType e)
{
    LinkStackPtr s = (LinkStackPtr)malloc(sizeof(StackNode));
    if (s == NULL)
    {
        printf("Memory allocation failed");
        return ERROR;
    }

    s->data = e;
    s->next = S->top;  // �ѵ�ǰ��ջ��Ԫ�ظ�ֵ���½���ֱ�Ӻ��
    S->top = s;        // ���µĽ��s��ֵ��ջ��ָ��
    S->count++;

    return OK;
}


/* ��ջ���� */
// ��ջSΪ��ջ���򷵻�TRUE�����򷵻�FALSE
Status StackEmpty(LinkStack S)
{
    if (S.count == 0)
        return TRUE;
    else
        return FALSE;
}

// ��ջ���գ���ɾ��S��ջ��Ԫ�أ���e������ֵ��������OK�����򷵻�ERROR
Status Pop(LinkStack* S, SElemType* e)
{
    LinkStackPtr p;
    if (StackEmpty(*S))
        return ERROR;

    *e = S->top->data;
    p = S->top;
    S->top = S->top->next;
    free(p);
    S->count--;

    return OK;
}
