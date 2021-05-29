#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

//模拟内存溢出

int main(void)
{
    while (1)
    {
        malloc(1024);
        usleep(10);
    }

    return (0);
}