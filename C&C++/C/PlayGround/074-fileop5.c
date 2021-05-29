#include <stdio.h>
#include <stdlib.h>

//文本文件写入，按字符串写入，fputs()

#define LEN 20

int main(void)
{
    FILE *fp;
    char ch, buffer[LEN];

    char filename[16];
    printf("please input the file name to write to:\n");
    scanf("%s", filename);

    if (!(fp = fopen(filename, "ar+")))
    {
        printf("can not open then file %s.\n", filename);
        exit(1);
    }

    printf("please input a string\n");
    fgets(buffer, LEN, stdin); //使用scanf()的话，无法读取空格，stdin是标准输入，即读取键盘
    fputs(buffer, fp);

    rewind(fp); //重新定义文件内部指针到文件的起始位置

    ch = fgetc(fp);
    while (ch != EOF)
    {
        putchar(ch);
        ch = fgetc(fp);
    }

    fclose(fp);

    printf("\n");

    return (0);
}