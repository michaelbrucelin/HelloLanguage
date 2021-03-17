#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

struct Node *createnode(long value);
struct Node *addnode(long value, struct Node *pNode);
void listnodes(struct Node *pNode);
void freenodes(struct Node *pNode);

struct Node
{
    long item;           //节点的值
    int count;           //具有该值节点的数量
    struct Node *pLeft;  //左子节点的指针
    struct Node *pRight; //右子节点的指针
};

int main(void)
{
    long newvalue = 0;
    struct Node *pRoot = NULL;
    char answer = 'n';
    do
    {
        printf("Enter the node value: ");
        scanf(" %ld", &newvalue);
        if (pRoot == NULL)
            pRoot = createnode(newvalue);
        else
            addnode(newvalue, pRoot);
        printf("\nDo you want to enter another (y or n)? ");
        scanf(" %c", &answer);
    } while (tolower(answer) == 'y');

    printf("The values in ascending sequence are: ");
    listnodes(pRoot);
    freenodes(pRoot);

    return 0;
}

struct Node *createnode(long value)
{
    struct Node *pNode = (struct Node *)malloc(sizeof(struct Node));
    pNode->item = value;
    pNode->count = 1;
    pNode->pLeft = pNode->pRight = NULL;
    return pNode;
}

struct Node *addnode(long value, struct Node *pNode)
{
    if (pNode == NULL)
        return createnode(value);

    if (value == pNode->item)
    {
        ++pNode->count;
        return pNode;
    }

    if (value < pNode->item)
    {
        if (pNode->pLeft == NULL)
        {
            pNode->pLeft = createnode(value);
            return pNode->pLeft;
        }
        else
            return addnode(value, pNode->pLeft);
    }
    else
    {
        if (pNode->pRight == NULL)
        {
            pNode->pRight = createnode(value);
            return pNode->pRight;
        }
        else
            return addnode(value, pNode->pRight);
    }
}

void listnodes(struct Node *pNode)
{
    if (pNode->pLeft != NULL)
        listnodes(pNode->pLeft);

    for (int i = 0; i < pNode->count; i++)
        printf("\n%10ld", pNode->item);

    if (pNode->pRight != NULL)
        listnodes(pNode->pRight);
}

void freenodes(struct Node *pNode)
{
    if (pNode == NULL)
        return;

    if (pNode->pLeft != NULL)
        freenodes(pNode->pLeft);

    if (pNode->pRight != NULL)
        freenodes(pNode->pRight);

    free(pNode);
}