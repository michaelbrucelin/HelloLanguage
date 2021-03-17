#include <stdio.h>
#include <stdlib.h>

//文件读取，从指定的位置读取，fread()
//读取使用的文件由076-fileop6.c产生

struct student
{
    char name[10];
    int num;
    int age;
    char addr[16];
} stu;

int main(void)
{
    FILE *fp;
    int i = 1; //设置为1，就是跳过1个成员，从第二个成员的位置开始读取

    if (!(fp = fopen("student-list", "r")))
    {
        printf("can not open the file!\n");
        return (1);
    }

    rewind(fp);                               //设置文件内部指针在文件头，正常情况下打开就在文件头，设置一下更保险
    fseek(fp, i * sizeof(struct student), 0); //设置偏移量
    fread(&stu, sizeof(struct student), 1, fp);

    printf("name\tnum\tage\taddress\n");
    printf("%s\t%d\t%d\t%s\n", stu.name, stu.num, stu.age, stu.addr);

    return (0);
}