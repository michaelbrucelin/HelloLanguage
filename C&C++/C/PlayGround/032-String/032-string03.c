#include <stdio.h>

int main()
{
    //使用指针法遍历数组
    char a[] = "hello world, hello mlin.", b[0], *p1, *p2;
    int i;

    p1 = a;
    p2 = b;

    for (; *p1 != '\0'; p1++, p2++)
    {
        *p2 = *p1;
    }
    *p2 = '\0';

    printf("string a is: %s\n", a);
    printf("string b is: ");
    //指针法取值
    for (i = 0; *(b + i) != '\0'; i++)
    {
        printf("%c", *(b + i));
    }
    printf("\n");
}