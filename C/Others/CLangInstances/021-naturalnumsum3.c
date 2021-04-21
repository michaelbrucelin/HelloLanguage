#include <stdio.h>

int addNumbers(int n);

int main()
{
    int num;
    printf("输入一个整数: ");
    scanf("%d", &num);
    printf("Sum = %d", addNumbers(num));
    return 0;
}

int addNumbers(int n)
{
    if (n != 0)
        return n + addNumbers(n - 1);
    else
        return n;
}