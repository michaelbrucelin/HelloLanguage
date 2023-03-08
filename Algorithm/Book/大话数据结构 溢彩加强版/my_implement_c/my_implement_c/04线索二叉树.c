/* ���������� */
#include "my_macro.h"

typedef char TElemType;
typedef enum { Link, Thread } PointerTag;  // Link=0��ʾָ�����Һ���ָ�룬Thread=1��ʾָ��ǰ�����̵�����

typedef struct BiThrNode                   // ���������洢���ṹ
{
    TElemType data;                        // �������
    struct BiThrNode* lchild, * rchild;    // ���Һ���ָ��
    PointerTag LTag, RTag;                 // ���ұ�־
} BiThrNode, * BiThrTree;


BiThrTree pre; /* ȫ�ֱ���,ʼ��ָ��ոշ��ʹ��Ľ�� */
/* ��������������������� */
void InThreading(BiThrTree p)
{
    if (p)
    {
        InThreading(p->lchild);  // �ݹ�������������
        if (!p->lchild)          // û������
        {
            p->LTag = Thread;    // ǰ������
            p->lchild = pre;     // ����ָ��ָ��ǰ��
        }
        if (!pre->rchild)        // ǰ��û���Һ���
        {
            pre->RTag = Thread;  // �������
            pre->rchild = p;     // ǰ���Һ���ָ��ָ����(��ǰ���p)
        }
        pre = p;                 // ����preָ��p��ǰ��
        InThreading(p->rchild);  // �ݹ�������������
    }
}


/* Tָ��ͷ��㣬ͷ�������lchildָ�����㣬ͷ�������rchildָ��������������һ����㡣 */
/* ��������������������ʾ�Ķ�����T */
Status InOrderTraverse_Thr(BiThrTree T)
{
    BiThrTree p;
    p = T->lchild; /* pָ������ */
    while (p != T) /* �������������ʱ,p==T */
    {
        while (p->LTag == Link) /*��LTag==0ʱѭ�����������е�һ����� */
            p = p->lchild;
        printf("%c", p->data); /* ��ʾ������ݣ����Ը���Ϊ�����Խ����� */
        while (p->RTag == Thread && p->rchild != T)
        {
            p = p->rchild;
            printf("%c", p->data); /* ���ʺ�̽�� */
        }
        p = p->rchild; /*  p�������������� */
    }
    return OK;
}
