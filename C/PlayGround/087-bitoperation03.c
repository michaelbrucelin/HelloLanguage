#include <stdio.h>
#include <stdlib.h>

//循环移位，将最后面的n位移到前面

int main(void)
{
    unsigned char a, b, c;
    int n;

    printf("please input a num:\n");
    scanf("%d", &a);
    printf("please input the length:\n");
    scanf("%d", &n);

    b = a << (sizeof(char) * 8 - n);
    c = a >> n;
    c = c | b;

    printf("the result is: %d\n", c);

    return (0);
}