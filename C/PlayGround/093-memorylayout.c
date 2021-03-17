#include <stdio.h>
#include <stdlib.h>

//打印结果，查找规律，看看C语言的内存布局

int global_uninit_var;
int global_init_var1 = 520;
int global_init_var2 = 880;

void func(void);

void func(void)
{
    ;
}

int main(void)
{
    int local_var1;
    int local_var2;

    static int static_uninit_var;
    static int static_init_var = 456;

    char *str1 = "Hello World.";
    char *str2 = "Hello U.";

    int *malloc_var = (int *)malloc(sizeof(int));

    printf("address of func              -->  %p\n", func);
    printf("address of str1              -->  %p\n", str1);
    printf("address of str2              -->  %p\n", str2);
    printf("address of global_init_var1  -->  %p\n", &global_init_var1);
    printf("address of global_init_var2  -->  %p\n", &global_init_var2);
    printf("address of static_init_var   -->  %p\n", &static_init_var);
    printf("address of static_uninit_var -->  %p\n", &static_uninit_var);
    printf("address of global_uninit_var -->  %p\n", &global_uninit_var);
    printf("address of malloc_var        -->  %p\n", malloc_var);
    printf("address of local_var1        -->  %p\n", &local_var1);
    printf("address of local_var2        -->  %p\n", &local_var2);

    return (0);
}

/*
编译后执行
#size a.out
   text    data     bss     dec     hex filename
   2330     604      12    2946     b82 a.out
可以看到内存中不同区域的大小，可以注释代码中的不同的变量，然后再编译执行size a.out对比前后的结果
*/