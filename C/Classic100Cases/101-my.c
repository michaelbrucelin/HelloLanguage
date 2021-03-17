/*
题目：魔术师发牌问题
问题描述：魔术师手里一共有13张牌，全是黑桃，1~13。
    魔术师需要实现一个魔术：这是十三张牌全部放在桌面上（正面向下），
    第1次摸出第1张，是1，翻过来放在桌面上；
    第2次摸出从上往下数第2张，是2，翻过来放在桌面上，（第1张放在最下面去，等会儿再摸）；
    第3次摸出从上往下数第3张，是3，翻过来放在桌面上，（第1张和第2张放在最下面去，等会儿再摸）；
    以此类推 最后一张就是13；

程序分析：使用循环链表初始化牌的顺序。
*/

#include <stdio.h>
#include <stdlib.h>

typedef int ElemType;
typedef struct LinkNode
{
    ElemType data;
    struct LinkNode *next;
} LinkNode;

int main(void)
{
    LinkNode *L, *cur;

    L = (LinkNode *)malloc(sizeof(LinkNode));
    if (L == NULL)
    {
        printf("没有足够的内存空间。\n");
        return 1;
    }

    //初始化环形链表，空链表，没有值
    cur = L;
    for (size_t i = 0; i < 13; i++)
    {
        cur->data = 0;
        if (i < 13 - 1)
        {
            cur->next = (LinkNode *)malloc(sizeof(LinkNode));
            if (L == NULL)
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

    //初始化环形链表的值，即牌的顺序
    L->data = 1;
    cur = L;
    for (size_t i = 2; i <= 13; i++)
    {
        for (size_t j = 0; j < i;)
        {
            cur = cur->next;
            if (cur->data == 0)
                j++;
        }
        cur->data = i;
    }

    //输出
    cur = L;
    for (size_t i = 0; i < 13; i++)
    {
        printf("黑桃%d  ", cur->data);
        cur = cur->next;
    }
    printf("\n");

    //释放内存
    cur = L;
    LinkNode *next;
    for (size_t i = 0; i < 12; i++)
    {
        next = cur->next;
        free(cur);
        cur = next;
    }
    free(cur);

    return (0);
}