#include <stdio.h>
#include <stdlib.h>

//文本文件读取，按字符读取，fgetc()

int main(void)
{
    FILE *fp;
    char ch, filename[32];

    printf("please input the filename you want to open: ");
    scanf("%s", filename);

    if (!(fp = fopen(filename, "r")))
    {
        printf("can not open the file %s\n", filename);
        exit(0);
    }

    while (ch != EOF) //EOF是宏，-1的意思（ASCII中没有-1，所以这里用EOF是合适的），Windows中键盘输入Ctrl+Z就是EOF，Linux中使用Ctrl+D
    {
        ch = fgetc(fp);
        putchar(ch);
    }

    fclose(fp); //关闭文件

    return (0);
}