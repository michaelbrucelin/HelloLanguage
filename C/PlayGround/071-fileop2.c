#include <stdio.h>
#include <stdlib.h>

//文本文件写入，按字符写入，fputc()

int main(void)
{
    FILE *fp;
    char ch, filename[32];

    printf("please input the filename you want to write to: ");
    scanf("%s", filename);

    if (!(fp = fopen(filename, "wt+")))
    {
        printf("can not open the file %s\n", filename);
        exit(0);
    }

    printf("please input the sentences you want to write: ");
    ch = getchar(); //这个是为了“吃掉”第一个回车
    ch = getchar();
    while (ch != EOF) //EOF是宏，-1的意思（ASCII中没有-1，所以这里用EOF是合适的），Windows中盘输入Ctrl+Z就是EOF，，Linux中使用Ctrl+D
    {
        fputc(ch, fp);
        ch = getchar();
    }

    fclose(fp); //关闭文件

    return (0);
}