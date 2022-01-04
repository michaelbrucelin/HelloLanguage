/*
题目：凯撒密码
问题描述：用户输入一个数字
    如果输入3：
        输出：DEFGHIJKLMNOPQRSTUVWXYZABC；
    如果输入-4：
        输出：WXYZABCDEFGHIJKLMNOPQRSTUV；

程序分析：使用双向循环链表实现。
*/

#include <stdio.h>
#include <stdlib.h>

#define N 26
#define START 65

typedef char ElemType;
typedef struct LinkNode
{
    ElemType data;
    struct LinkNode *piror;
    struct LinkNode *next;
} LinkNode;

int main(void)
{
    LinkNode *L, *cur;
    int offset;

    printf("请输入一个整数： ");
    scanf("%d", &offset);

    L = (LinkNode *)malloc(sizeof(LinkNode));
    if (L == NULL)
    {
        printf("没有足够的内存空间。\n");
        return 1;
    }

    //初始化一个双向循环链表
    cur = L;
    for (size_t i = 0; i < N; i++)
    {
        cur->data = START + i;
        if (i < N - 1)
        {
            cur->next = (LinkNode *)malloc(sizeof(LinkNode));
            if (L == NULL)
            {
                printf("没有足够的内存空间。\n");
                return 1;
            }
            cur->next->piror = cur;
            cur = cur->next;
        }
        else
        {
            cur->next = L;
            L->piror = cur;
        }
    }

    //输出
    cur = L;
    if (offset > 0)
        for (size_t i = 0; i < offset; i++)
            cur = cur->next;
    else if (offset < 0)
        for (size_t i = 0; i < -1 * offset; i++)
            cur = cur->piror;

    for (size_t i = 0; i < N; i++)
    {
        printf("%c ", cur->data);
        cur = cur->next;
    }
    printf("\n");

    //释放内存
    LinkNode *next;
    cur = L;
    for (size_t i = 0; i < N - 1; i++)
    {
        next = cur->next;
        free(cur);
        cur = cur->next;
    }
    free(next);

    return (0);
}