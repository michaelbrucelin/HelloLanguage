/*
题目：有n个人围成一圈，顺序排号。从第一个人开始报数（从1到3报数），凡报到3的人退出圈子，问最后留下的是原来第几号的那位。

程序分析：使用环形链表实现。
*/

#include <stdio.h>
#include <stdlib.h>

#define N 3 //报3的人移除

typedef int ElemType;
typedef struct LinkNode
{
    ElemType data;
    struct LinkNode *next;
} LinkNode;

int main(void)
{
    LinkNode *L, *cur, *preNode;
    int baoshu = 1, count = 0;

    printf("请输入人员的数量： ");
    scanf("%d", &count);

    L = (LinkNode *)malloc(sizeof(LinkNode));
    if (L == NULL)
    {
        printf("没有足够的内存空间。\n");
        return 1;
    }

    //初始化环形链表
    cur = L;
    for (size_t i = 0; i < count; i++)
    {
        cur->data = i + 1;
        if (i < count - 1)
        {
            cur->next = (LinkNode *)malloc(sizeof(LinkNode));
            if (cur->next == NULL)
            {
                printf("没有足够的内存空间。\n");
                return 1;
            }
            cur = cur->next;
        }
        else
        {
            cur->next = L;
        }
    }

    preNode = cur;
    cur = L;
    while (cur != cur->next)
    {
        if (((baoshu++ - 1) % 3 + 1) == N)
        {
            preNode->next = cur->next;
            free(cur);
            cur = preNode->next;
        }
        else
        {
            cur = cur->next;
            preNode = preNode->next;
        }
        L = cur;
    }

    printf("[linklist]余下第%d号人。\n", L->data);
    free(L);

    return (0);
}