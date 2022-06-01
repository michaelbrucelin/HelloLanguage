#include <stdlib.h>

#define OK 1
#define ERROR 0
#define TRUE 1
#define FALSE 0
#define OVERFLOW -2 /* 堆溢出，add by michaelbrucelin */

typedef int Status; /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

/* 二叉树的二叉线索存储结构定义 */
typedef char TElemType;
typedef enum
{
    Link,
    Thread
} PointerTag;            /* Link=0表示指向左右孩子指针, */
                         /* Thread=1表示指向前驱或后继的线索 */
typedef struct BiThrNode /* 二叉线索存储结点结构 */
{
    TElemType data;                    /* 结点数据 */
    struct BiThrNode *lchild, *rchild; /* 左右孩子指针 */
    PointerTag LTag;
    PointerTag RTag; /* 左右标志 */
} BiThrNode, *BiThrTree;

BiThrTree pre; /* 全局变量,始终指向刚刚访问过的结点 */
/* 中序遍历进行中序线索化 */
void InThreading(BiThrTree p)
{
    if (p)
    {
        InThreading(p->lchild); /* 递归左子树线索化 */
        if (!p->lchild)         /* 没有左孩子 */
        {
            p->LTag = Thread; /* 前驱线索 */
            p->lchild = pre;  /* 左孩子指针指向前驱 */
        }
        if (!pre->rchild) /* 前驱没有右孩子 */
        {
            pre->RTag = Thread; /* 后继线索 */
            pre->rchild = p;    /* 前驱右孩子指针指向后继(当前结点p) */
        }
        pre = p;                /* 保持pre指向p的前驱 */
        InThreading(p->rchild); /* 递归右子树线索化 */
    }
}

/* T指向头结点，头结点左链lchild指向根结点，头结点右链rchild指向中序遍历的*/
/* 最后一个结点。中序遍历二叉线索链表表示的二叉树T */
Status InOrderTraverse_Thr(BiThrTree T)
{
    BiThrTree p;
    p = T->lchild; /* p指向根结点 */
    while (p != T) /* 空树或遍历结束时,p==T */
    {
        while (p->LTag == Link) /*当LTag==0时循环到中序序列第一个结点 */
            p = p->lchild;
        printf("%c", p->data); /* 显示结点数据，可以更改为其他对结点操作 */
        while (p->RTag == Thread && p->rchild != T)
        {
            p = p->rchild;
            printf("%c", p->data); /* 访问后继结点 */
        }
        p = p->rchild; /*  p进至其右子树根 */
    }
    return OK;
}

/*
if (a < 60)
    b = "不及格";
else if (a < 70)
    b = "及格";
else if (a < 80)
    b = "中等";
else if (a < 90)
    b = "良好";
else
    b = "优秀";
*/
