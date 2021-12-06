#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

//自己实现一个动态链表，动态的添加元素，删除元素

#define LEN sizeof(struct student) //student结构的大小

struct student *create();                               //创建链表
struct student *delete (struct student *head, int num); //删除元素，*head即链表的头指针，num是要删除元素的number
void print(struct student *head);                       //打印链表

struct student
{
    long num;
    float score;
    struct student *next;
};

int cnt; //全局变量，用来记录存放了多少数据

int main(void)
{
    struct student *stu;
    int num2del;

    stu = create();
    printf("\n\n");
    print(stu);
    printf("\n\n");

    printf("please enter the num to delete:");
    scanf("%d", &num2del);
    print(delete (stu, num2del));

    printf("\n");
    //system("pause");

    return (0);
}

//这里约定学号不能为0，当输入0时表示输入结束
struct student *create()
{
    struct student *head;
    struct student *pa, *pz;

    pa = pz = (struct student *)malloc(LEN); //LEN是student结构的大小

    printf("please enter the num: ");
    scanf("%d", &(pz->num));
    printf("please enter the score: ");
    scanf("%f", &(pz->score));

    head = NULL;
    cnt = 0;

    while (pz->num)
    {
        cnt++;
        if (cnt == 1)
        {
            head = pz;
        }
        else
        {
            pa->next = pz;
        }

        pa = pz;
        pz = (struct student *)malloc(LEN);

        printf("please enter the num: ");
        scanf("%d", &(pz->num));
        printf("please enter the score: ");
        scanf("%f", &(pz->score));
    }

    pa->next = NULL;

    return head;
}

struct student *delete (struct student *head, int num)
{
    struct student *pa, *pz;

    if (head == NULL) //如果头指针指向NULL，则这是一个空链表
    {
        printf("this list is null\n");
        goto END;
    }

    pz = head;
    while (pz->num != num && pz->next != NULL)
    {
        pa = pz;
        pz = pz->next;
    }
    if (pz->num == num)
    {
        if (pz == head) //当要删除的元素为与头节点时
        {
            head = pz->next;
        }
        else //一般情况
        {
            pa->next = pz->next;
        }
        printf("delete NO: %d succeed.\n", num);
        cnt--; //cnt是全局变量，用来记录链表元素的个数
    }
    else
    {
        printf("%d not found.\n", num);
    }
END:

    return head;
}

void print(struct student *head)
{
    struct student *p;
    printf("there %s %d record%s!\n", cnt == 1 ? "is" : "are", cnt, cnt == 1 ? "" : "s");

    p = head;
    if (head)
    {
        do
        {
            printf("number: %d\tscore: %f\n", p->num, p->score);
            p = p->next;
        } while (p);
    }
}