#include <stdio.h>
#include <stdlib.h>

//文本文件读取，按字符串读取，fgets()

#define LEN 11 //长度为10，最后为\0

int main(void)
{
    FILE *fp;
    char buffer[LEN];

    char filename[16];
    printf("please input the file name to write to:\n");
    scanf("%s", filename);

    if (!(fp = fopen(filename, "rt")))
    {
        printf("can not open then file %s.\n", filename);
        exit(1);
    }

    fgets(buffer, LEN, fp);
    printf("%s\n", buffer);

    fclose(fp);

    return (0);
}