#include <stdio.h>

const char *calculateMonth(int month)
{
    static char *months[] = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
    static char badFood[] = "Unknown";
    if (month < 1 || month > 12)
        return badFood; // Choose whatever is appropriate for bad input. Crashing is never appropriate however.
    else
        return months[month - 1];
}

int main()
{
    printf("%s", calculateMonth(2)); // Prints "Feb"
}

/*
函数返回字符串的使用方法
链接：https://stackoverflow.com/questions/1496313/returning-a-c-string-from-a-function

What the static does here (many programmers do not like this type of 'allocation') is that the strings get put into the data segment of the program. That is, it's permanently allocated.
static 在这里的作用（许多程序员不喜欢这种类型的“分配”）是将字符串放入程序的数据段中。 也就是说，它是永久分配的。
*/