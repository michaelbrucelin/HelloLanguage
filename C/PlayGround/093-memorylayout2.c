#include <stdio.h>
#include <stdlib.h>

//验证栈的地址由高到低，而堆的地址由低到高

int main()
{
    int *ptr1 = NULL;
    int *ptr2 = NULL;

    ptr1 = (int *)malloc(sizeof(int));
    ptr2 = (int *)malloc(sizeof(int));

    printf("stack: %p --> %p\n", &ptr1, &ptr2);
    printf("heap:  %p --> %p\n", ptr1, ptr2);

    return (0);
}

/*
#./a.out 
stack: 0x7ffcc423c4c8 --> 0x7ffcc423c4c0
heap:  0x5560d07fd260 --> 0x5560d07fd280
*/