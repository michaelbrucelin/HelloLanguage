#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    FILE *in, *out;
    int ch;

    if (argc != 3)
    {
        fprintf(stderr, "输入形式：copyfile srcfile dstfile\n");
        exit(EXIT_FAILURE);
    }

    if ((in = fopen(argv[1], "rb")) == NULL)
    {
        fprintf(stderr, "无法打开源文件：%s\n", argv[1]);
        exit(EXIT_FAILURE);
    }

    if ((out = fopen(argv[2], "wb")) == NULL)
    {
        fprintf(stderr, "无法打开目标文件：%s\n", argv[2]);
        fclose(in); //记得擦屁股
        exit(EXIT_FAILURE);
    }

    while ((ch = getc(in)) != EOF) //end of file
    {
        if (putc(ch, out) == EOF)
            break;
    }

    if (ferror(in))
        printf("读取源文件 %s 失败！\n", argv[1]);

    if (ferror(out))
        printf("写入目标文件 %s 失败！\n", argv[2]);

    printf("C成功复制1个文件！\n");

    fclose(in);
    fclose(out);

    return (0);
}