#include <stdio.h>

#define HELLO "Hello, World!"

int main(void)
{
    printf("%s\n", HELLO);
    return 0;
}

/*
gcc -E hello.c  # gcc -E 输出的是预处理后，编译前的代码
*/