#include <stdio.h>

void main()
{
    short a, b;
    a = 32767;
    b = a + 1;
    printf("%d, %d\n", a, b);
}

// 结果会溢出，结果输出为 32767, -32768
// 32767:  0111 1111 1111 1111
// -32768: 1000 0000 0000 0000