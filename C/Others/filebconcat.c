#include <stdio.h>
#include <stdlib.h>

/*
将两个文件以二进制的形式连接在一起，拼接成一个文件
常用于将一个图片和一个种子（压缩为rar）合并为一个“图片”，这个图片和原图一样，当把合成后的图片的后缀名改为rar后，就和合并前的rar包一样
*/

int main(void)
{
    FILE *f_pic, *f_file, *f_concat;
    char ch, pic_name[32], file_name[32], concat_name[32];

    printf("please input the picture name:\n");
    scanf("%s", pic_name);
    printf("please input the file name:\n");
    scanf("%s", file_name);
    printf("please input the concated file name:\n");
    scanf("%s", concat_name);

    if (!(f_pic = fopen(pic_name, "rb")))
    {
        printf("can not open the pictrue %s!\n", pic_name);
        return (1);
    }
    if (!(f_file = fopen(file_name, "rb")))
    {
        printf("can not open the file %s!\n", file_name);
        return (1);
    }
    if (!(f_concat = fopen(concat_name, "wb")))
    {
        printf("can not open the concated file %s!\n", concat_name);
        return (1);
    }

    while (!(feof(f_pic)))
    {
        ch = fgetc(f_pic);
        fputc(ch, f_concat);
    }
    fclose(f_pic);

    while (!(feof(f_file)))
    {
        ch = fgetc(f_file);
        fputc(ch, f_concat);
    }
    fclose(f_file);

    fclose(f_concat);

    return (0);
}