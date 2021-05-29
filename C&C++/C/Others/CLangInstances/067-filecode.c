#include <stdio.h>

/*
输出当前文件执行代码，__FILE__ 为当前执行的文件常量
*/

int main()
{
    FILE *fp;
    char c;
    fp = fopen(__FILE__, "r");
    do
    {
        c = getc(fp);
        putchar(c);
    } while (c != EOF);
    fclose(fp);
    return 0;
}