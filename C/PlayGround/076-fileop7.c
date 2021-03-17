#include <stdio.h>

//文件读取，按数据块读取，fread()
//读取使用的文件由076-fileop6.c产生

#define SIZE 4

struct student
{
    char name[10];
    int num;
    int age;
    char addr[16];
} stu[SIZE];

void load();

int main(void)
{
    load();
    printf("name\tnum\tage\taddress\n");
    for (size_t i = 0; i < SIZE; i++)
    {
        printf("%s\t%d\t%d\t%s\n", stu[i].name, stu[i].num, stu[i].age, stu[i].addr);
    }

    return (0);
}

void load()
{
    FILE *fp;
    int i;

    if (!(fp = fopen("student-list", "r")))
    {
        printf("can not open the file!\n");
        return;
    }

    for (i = 0; i < SIZE; i++)
    {
        fread(&stu[i], sizeof(struct student), 1, fp);
    }
    fclose(fp);
}