#include <stdio.h>
#include <stdlib.h>

//打开关闭文件

int main(void)
{
    char *p = (char *)malloc(sizeof(char) * 255);
    printf("input file path to open\n");
    scanf("%s", p);

    FILE *fp;
    if (!(fp = fopen(p, "r")))
    {
        printf("Can not open file %s\n", p);
    }
    else
    {
        printf("Open file %s success!\n", p);
        fclose(fp);
    }

    return (0);
}