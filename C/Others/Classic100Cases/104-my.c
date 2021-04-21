/*
题目：做一个双向链表练练手

程序分析：
*/

#include <stdio.h>
#include <stdlib.h>

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

//方便测试用的
void PrintTest()
{
    Print();
    ReversePrint();
}

//方便测试用的
void FreeTest(LinkNode *e)
{
    if (e->data != '\0')
    {
        printf("delete: %c\n", e->data);
    }
}

int main(void)
{
    head = tail = NULL;
    LinkNode delete;

    printf("c:\n");
    InsertAtTail('c');
    PrintTest();

    printf("c,d:\n");
    InsertAtTail('d');
    PrintTest();

    printf("b,c,d:\n");
    InsertAtHead('b');
    PrintTest();

    printf("b,c,d,e:\n");
    InsertAtTail('e');
    PrintTest();

    printf("a,b,c,d,e:\n");
    InsertAtHead('a');
    PrintTest();

    printf("b,c,d,e:\n");
    DeleteAtHead(&delete);
    FreeTest(&delete);
    PrintTest();

    printf("b,c,d:\n");
    DeleteAtTail(&delete);
    FreeTest(&delete);
    PrintTest();

    printf("c,d:\n");
    DeleteAtHead(&delete);
    FreeTest(&delete);
    PrintTest();

    printf("c:\n");
    DeleteAtTail(&delete);
    FreeTest(&delete);
    PrintTest();

    printf("null:\n");
    DeleteAtHead(&delete);
    FreeTest(&delete);
    PrintTest();

    printf("null:\n");
    DeleteAtTail(&delete);
    FreeTest(&delete);
    PrintTest();

    return (0);
}