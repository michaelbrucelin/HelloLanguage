#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

//自己实现一个动态链表，动态的添加元素，插入元素
//程序在windows下运行正常，在Linux下，元素每次都插入到了最后，windows中使用的也是gcc编译器，怀疑是shell输入的问题

#define LEN sizeof(struct student) //student结构的大小

struct student *create();                                              //创建链表
struct student *insert(struct student *head, struct student *stu2ist); //插入元素，*head即链表的头指针，stu2ist是要出插入的元素
void print(struct student *head);                                      //打印链表

struct student
{
    long num;
    float score;
    struct student *next;
};

int cnt; //全局变量，用来记录存放了多少数据

int main(void)
{
    struct student *stu, stu2ist;
    int num2del;

    stu = create();
    printf("\n\n");
    print(stu);
    printf("\n\n");

    printf("please enter the student to insert:");
    scanf("%d", &(stu2ist.num));
    printf("please enter the score:");
    scanf("%f", &(stu2ist.score));
    print(insert(stu, &stu2ist));

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

struct student *insert(struct student *head, struct student *stu)
{
    struct student *pa, *pz;

    pz = head;
    if (pz == NULL) //空链表
    {
        head = stu;
        stu->next = NULL;
    }
    else
    {
        while ((pz->num <= stu->num) && (pz->next != NULL))
        {
            pa = pz;
            pz = pz->next;
        }
        if (pz->num > stu->num) //上面while限定，如果在这里pz.num仍然小于等于stu.num，就说明pz已经是链表最后的元素了
        {
            if (pz == head) //stu最小，插入到头部
            {
                head = stu;
            }
            else //一般情况，插入到中间
            {
                pa->next = stu;
            }

            stu->next = pz;
        }
        else //stu最大，插入到尾部
        {
            pz->next = stu;
            stu->next = NULL;
        }
    }

    cnt++;

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