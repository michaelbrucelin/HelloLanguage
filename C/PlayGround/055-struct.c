#include <stdio.h>

struct stu
{
    int num;
    char *name;
    char sex;
    float score;
};

int main(void)
{
    struct stu boy1;
    boy1.num = 001;
    boy1.name = "tom";
    boy1.sex = 'M';
    boy1.score = 99;

    struct stu boy2 = {002, "jim", 'M', 98};

    struct stu *pstu1;
    pstu1 = &boy1;

    //以结构调取成员的方法输出成员的值
    printf("Number = %03d, Name = %s, Sex = %c, Score = %f.\n", boy1.num, boy1.name, boy1.sex, boy1.score);
    //以结构调取成员的方法输出成员的值，通过指针获取结构
    printf("Number = %03d, Name = %s, Sex = %c, Score = %f.\n", (*pstu1).num, (*pstu1).name, (*pstu1).sex, (*pstu1).score);
    //以结构的指针调取成员的方法输出成员的值
    printf("Number = %03d, Name = %s, Sex = %c, Score = %f.\n", pstu1->num, pstu1->name, pstu1->sex, pstu1->score);

    return (0);
}