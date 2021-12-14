#include <stdio.h>

//自己模拟一个链表

struct student
{
    long num;
    float score;
    struct student *next;
};

int main(void)
{
    struct student a, b, c, *head;

    a.num = 10001;
    a.score = 89.5;
    b.num = 10002;
    b.score = 90;
    c.num = 10003;
    c.score = 85;

    head = &a;
    a.next = &b;
    b.next = &c;
    c.next = NULL;

    do
    {
        printf("%ld %5.1f\n", head->num, head->score);
        head = head->next;
    } while (head);

    return (0);
}