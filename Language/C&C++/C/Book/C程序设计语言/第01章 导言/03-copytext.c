/*
 * 读一个字符
 * while (该字符不是文件结束指示符)
 *     输出刚读入的字符
 *     读下一个字符
 * 将上述基本思想转换为C语言程序为：
 */

#include <stdio.h>

/* copy input to output; 1st version */
main()
{
    int c;
    c = getchar();
    while (c != EOF)
    {
        putchar(c);
        c = getchar();
    }
}