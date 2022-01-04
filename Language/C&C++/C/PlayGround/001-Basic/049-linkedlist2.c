#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>

//自己实现一个动态链表，动态的添加元素

#define LEN sizeof(struct student) //student结构的大小

struct student *create();         //创建链表
void print(struct student *head); //打印链表

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

    stu = create();
    printf("\n\n");
    print(stu);

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