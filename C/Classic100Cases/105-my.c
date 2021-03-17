/*
题目：表达式转换（群呼测试时，测试表达式）
    1*20      --> 1,1,1...1(共20个1)
    1*5+2     --> 1,1,1,1,1,2
    1*3+2+3*2 --> 1,1,1,2,3,3

程序分析：使用双向链表来实现，主要是做一个双向链表练练手。
    逐个字符读取，如果是数字，从尾部插入双向链表；
    如果是+号，忽略；
    如果是*号，取出双向链表最后一个元素（移除），读取下一个数字，假定为y，在双向链表尾部插入y个x
    从头部逐项输出双向链表
*/

#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

#define EXP_MAX_LEN 256

typedef char ElemType;
typedef struct LinkNode
{
    ElemType data;
    struct LinkNode *prev;
    struct LinkNode *next;
} LinkNode;

LinkNode *head; //全局变量 - 指向头节点
LinkNode *tail; //全局变量 - 指向尾节点

//创建一个新节点，并返回指向它的指针
LinkNode *GetNewNode(ElemType x)
{
    LinkNode *newNode = (LinkNode *)malloc(sizeof(LinkNode));
    newNode->data = x;
    newNode->prev = NULL;
    newNode->next = NULL;
    return newNode;
}

//在双向链表的头部插入一个新节点
void InsertAtHead(ElemType x)
{
    LinkNode *newNode = GetNewNode(x);
    if (head == NULL)
    {
        head = tail = newNode;
        return;
    }
    head->prev = newNode;
    newNode->next = head;
    head = newNode;
}

//在双向链表的尾部插入一个新节点
void InsertAtTail(ElemType x)
{
    LinkNode *newNode = GetNewNode(x);
    if (tail == NULL)
    {
        head = tail = newNode;
        return;
    }
    tail->next = newNode;
    newNode->prev = tail;
    tail = newNode;
}

//在双向链表的尾部插入一个新节点，这个是没有添加尾节点指针（tail）时的实现
void InsertAtTail0(ElemType x)
{
    LinkNode *temp = head;
    LinkNode *newNode = GetNewNode(x);
    if (head == NULL)
    {
        head = newNode;
        return;
    }
    while (temp->next != NULL)
        temp = temp->next; //游标到尾节点
    temp->next = newNode;
    newNode->prev = temp;
}

//删除双向链表的头结点
void DeleteAtHead(LinkNode *e)
{
    if (head == NULL)
    {
        e->data = '\0';
        return;
    }
    if (head == tail)
    {
        e->data = head->data;
        head = tail = NULL;
        return;
    }
    e->data = head->data;
    LinkNode *temp = head;
    head = head->next;
    head->prev = NULL;
    free(temp);
}

//删除双向链表的尾结点
void DeleteAtTail(LinkNode *e)
{
    if (tail == NULL)
    {
        e->data = '\0';
        return;
    }
    if (tail == head)
    {
        e->data = tail->data;
        tail = head = NULL;
        return;
    }
    e->data = tail->data;
    LinkNode *temp = tail;
    tail = tail->prev;
    tail->next = NULL;
    free(temp);
}

//正向输出双向链表的每个节点
void Print()
{
    LinkNode *temp = head;
    printf("Forward: ");
    while (temp != NULL)
    {
        printf("%c ", temp->data);
        temp = temp->next;
    }
    printf("\n");
}

//逆向输出双向链表的每个节点
void ReversePrint()
{
    LinkNode *temp = tail;
    printf("Reverse: ");
    while (temp != NULL)
    {
        printf("%c ", temp->data);
        temp = temp->prev;
    }
    printf("\n");
}

//逆向输出双向链表的每个节点，这个是没有添加尾节点指针（tail）时的实现
void ReversePrint0()
{
    LinkNode *temp = head;
    if (temp == NULL)
        return; // 空链表，退出
    // 游标到尾节点
    while (temp->next != NULL)
    {
        temp = temp->next;
    }
    // 使用前置指针向前遍历
    printf("Reverse: ");
    while (temp != NULL)
    {
        printf("%c ", temp->data);
        temp = temp->prev;
    }
    printf("\n");
}

int main(void)
{
    head = tail = NULL;
    LinkNode delete;

    printf("please input a expression(e.g. 1*3+2+3*2): ");
    char exp[EXP_MAX_LEN];
    if (!fgets(exp, sizeof(exp), stdin))
    {
        printf("input failed!\n");
        exit(1);
    }

    char *e = exp;
    int x = 0;
    while (*e)
    {
        if (isdigit(*e))
            InsertAtTail(*e);
        else if (*e == '*')
        {
            DeleteAtTail(&delete);
            if (delete.data != '\0')
            {
                e++;
                x = *e - 48; //字符数字转成整型数字
                for (int i = 0; i < x; i++)
                {
                    InsertAtTail(delete.data);
                }
            }
        }

        e++;
    }

    Print();

    return (0);
}