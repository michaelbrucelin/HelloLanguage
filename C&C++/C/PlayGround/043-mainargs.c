#include <stdio.h>

/*
main函数的三个参数：
第一个参数argc，用于存放命令行参数的个数，包括程序名称在内。
第二个参数argv，是个字符指针的数组，每个元素都是一个字符指针，指向一个字符串，即命令行中的每一个参数。
第三个参数envp，也是一个字符指针的数组，这个数组的每一个元素是指向一个环境变量的字符指针。
*/

int main(int argc, char *argv[])
{
    if (argc == 1)
    {
        printf("没有输入参数\n");
    }
    else
    {
        printf("输入了%d个参数\n", argc - 1);
        for (int i = 0; i < argc; i++)
        {
            printf("%s\n", argv[i]);
        }
    }

    return 0;
}