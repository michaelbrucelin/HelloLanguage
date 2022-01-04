#include <stdio.h>
#include <string.h> // function strcpy

int main()
{
    // C语言中没有独立的字符串数据类型，需要使用字符数组或字符指针这个数据结构来实现字符串
    // 两种实现在汇编的层面看是不一样的

    // 1. 使用字符数组实现字符串
    char strarr[] = "hello string with char array.";
    printf("%s\n", strarr);

    char strarr2[255];
    // strarr2 = "hello string with char array.";  // 这样是错误的
    strcpy(strarr2, "hello string with char array.");
    printf("%s\n", strarr2);

    // 2. 使用指针来实现字符串
    char *strp = "hello string with char pointer.";
    printf("%s\n", strp);

    char *strp2;
    strp2 = "hello string with char pointer.";
    printf("%s\n", strp2);
}