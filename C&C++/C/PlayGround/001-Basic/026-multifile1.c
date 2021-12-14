#include <stdio.h>

void main()
{
    int a, b;
    printf("input two numbers\n");
    scanf("%d %d", &a, &b);

    int myadd(int a, int b);

    printf("a + b = %d\n", myadd(a, b));
}

//需要将两个文件一起编译，而不需要在文件中添加引用
//gcc 026-multifile{1,2}.c -o mfile