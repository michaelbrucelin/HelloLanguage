#include <stdio.h>

int main()
{
    //使用下标法遍历数组
    //这里b数组的长度声明为0没有问题，声明的比较长也没有问题，但是如果声明为b[1]，会吃掉a[]的第一个元素，如果声明为b[2]，会吃掉a[]的前2个元素... ...，不确认是为什么
    char a[] = "hello world, hello mlin.", b[0];
    int i;
    for (i = 0; *(a + i) != '\0'; i++)
    {
        *(b + i) = *(a + i);
    }
    *(b + i) = '\0';

    printf("string a is: %s\n", a);
    printf("string b is: ");
    //下标法取值
    for (i = 0; b[i] != '\0'; i++)
    {
        printf("%c", b[i]);
    }
    printf("\n");
}