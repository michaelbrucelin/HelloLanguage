#include <stdio.h>
#include <stdlib.h>

void myfunc(void)
{
    printf("Hello, World! This Program Start From Here.\n");
    exit(0);
}

/*
这样编译就可以将程序的入口函数替换为myfunc，从而达到程序的入口函数被替换的目的。
# gcc -nostartfiles -emyfunc nomain.c
# ./a.out
> Hello, World! This Program Start From Here.
*/