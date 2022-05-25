// 双向链表
// p = rearA->next;                  /* 保存A表的头结点，即① */
// rearA->next = rearB->next->next;  /* 将本是指向B表的第一个结点（不是头结点） */
//                                   /* 赋值给reaA->next，即② */
// q = rearB->next;
// rearB->next = p;  /* 将原A表的头结点赋值给rearB->next，即③ */
// free(q);          /* 释放q */

/* 线性表的双向链表存储结构 */
typedef int ElemType; /* ElemType类型根据实际情况而定，这里为int */

typedef struct DulNode
{
    ElemType data;
    struct DuLNode *prior; /* 直接前驱指针 */
    struct DuLNode *next;  /* 直接后继指针 */
} DulNode, *DuLinkList;

// p->next->prior = p = p->prior->next;
//
// s->prior = p;        /* 把p赋值给s的前驱，如图中① */
// s->next = p->next;   /* 把p->next赋值给s的后继，如图中② */
// p->next->prior = s;  /* 把s赋值给p->next的前驱，如图中③ */
// p->next = s;         /* 把s赋值给p的后继，如图中④ */
//
// p->prior->next = p->next;   /* 把p->next赋值给p->prior的后继，如图中① */
// p->next->prior = p->prior;  /* 把p->prior赋值给p->next的前驱，如图中② */
// free(p);                    /* 释放结点 */
