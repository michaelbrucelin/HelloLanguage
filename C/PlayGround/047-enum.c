#include <stdio.h>

int main(void)
{
    enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    enum Weekday today = Saturday;
    int n = -1;
    while (n < 0 || n > 6)
    {
        printf("input a number between 0~6\n");
        scanf("%d", &n);
    }

    enum Weekday inputday = n; //虽然枚举类型存储的也是整型，但是和char一样像这样直接使用整型赋值

    printf("today is %s\n", today); //也无法这样输出，据说只能创建一个对应的字符串数组来间接实现，这里就不尝试了
    printf("today is %d\n", today);
    printf("inputday is %s\n", inputday);

    return (0);
}