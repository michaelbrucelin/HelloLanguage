#include <stdio.h>

//文件写入，按数据块写入，fwrite()

#define SIZE 4

struct student
{
    char name[10];
    int num;
    int age;
    char addr[16];
} stu[SIZE];

void save();

int main(void)
{
    int i;

    printf("please input the student's name, num, age, address:\n");
    for (i = 0; i < SIZE; i++)
    {
        //scanf("%s %d %d %s", stu[i].name, stu[i].num, stu[i].age, stu[i].addr);  //为什么这样是错的？
        scanf("%s %d %d %s", stu[i].name, &stu[i].num, &stu[i].age, &stu[i].addr); //scanf要的是指针，结构名就是结构第一个成员的地址
    }

    save();

    return (0);
}

void save()
{
    FILE *fp;
    int i;

    if (!(fp = fopen("student-list", "wb")))
    {
        printf("can not open the file student-list!\n");
        return;
    }

    for (int i = 0; i < SIZE; i++)
    {
        if (fwrite(&stu[i], sizeof(struct student), 1, fp) != 1)
        {
            printf("file write error!\n");
            fclose(fp);
        }
    }

    fclose(fp);
}
