#include <stdio.h>
#include <stdlib.h>

int main(void)
{
    unsigned char a, b, c;
    int n;

    printf("please input the number you want to operate:\n");
    scanf("%d", &a);
    printf("please input the length you want to move:\n");
    scanf("%d", &n);

    b = a << (sizeof(char) * 8 - n); //结果的左部
    c = a >> n;                      //结果的右部
    c = c | b;                       //结果

    printf("the result is: %c\n", c);

    return (0);
}