#include <stdio.h>

/*
main函数的三个参数：
第一个参数argc，用于存放命令行参数的个数，包括程序名称在内。
第二个参数argv，是个字符指针的数组，每个元素都是一个字符指针，指向一个字符串，即命令行中的每一个参数。
第三个参数envp，也是一个字符指针的数组，这个数组的每一个元素是指向一个环境变量的字符指针。

argc （“参数计数”）是命令行参数的数量（包括程序名本身）。
argv （“参数向量”）是指向命令行参数的指针数组，这些命令行参数以字符串的形式存储。
    argv[0] 指向程序名，而从argv[1]到argv[argc-1]则指向余下的命令行参数。
    argv有一个附加元素，即argv[argc]，这个元素始终是一个空指针。空指针是一种不指向任何地方的特殊指针。
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

/*
# ./test
没有输入参数

#./test a 1 b 2
输入了4个参数
./test
a
1
b
2

# ls
args.c  str  str.c  test  test-c.ly  test.txt
#./test *
输入了6个参数
./test
args.c
str
str.c
test
test-c.ly
test.txt
*/
