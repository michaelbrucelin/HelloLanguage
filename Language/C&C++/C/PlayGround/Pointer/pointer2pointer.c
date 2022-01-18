#include <stdlib.h>

struct node
{
    int value;         // data stored in the node
    struct node *next; // pointer to the next node
};

// 下面写法是正确的，返回链表首节点的指针
struct node *add_to_list(struct node *list, int n)
{
    struct node *new_node;

    new_node = malloc(sizeof(struct node));
    if (new_node == NULL)
    {
        printf("Error: malloc failed in add_to_list\n");
        exit(EXIT_FAILURE);
    }
    new_node->value = n;
    new_node->next = list;

    return new_node;
}

// 下面写法的本意是直接将新节点插入到链表中，但是写法是错误的，分析一下是为什么？
void add_to_list(struct node *list, int n)
{
    struct node *new_node;

    new_node = malloc(sizeof(struct node));
    if (new_node == NULL)
    {
        printf("Error: malloc failed in add_to_list\n");
        exit(EXIT_FAILURE);
    }
    new_node->value = n;
    new_node->next = list;
    list = new_node;
}

// 下面写法是正确的，直接将新节点插入到链表中
void add_to_list(struct node **list, int n)
{
    struct node *new_node;

    new_node = malloc(sizeof(struct node));
    if (new_node == NULL)
    {
        printf("Error: malloc failed in add_to_list\n");
        exit(EXIT_FAILURE);
    }
    new_node->value = n;
    new_node->next = *list;
    *list = new_node;
}

/*原因，指针参数是值传递的
现在有list，list是链表的头结点
1. 错误的写法，形参是一个指针，尽管调用时将list的地址传递给了函数，但是由于指针是值传递，所以函数内部的list的地址是一个副本，改变了副本的值（地址）并不能真的改变list的地址，所以是错误的；
2. 正确的写法，形参是一个指向指针的指针（**list），这时**list仍然是值传递，所以函数内部的**list仍然是一个副本，但是**list指向的地址中是外部list的地址，所以改变了**list指向的地址中的值，也能改变外部list的地址，所以是正确的；
*/