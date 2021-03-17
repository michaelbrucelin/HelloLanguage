/*
题目：二分法查找

程序分析：使用递归来实现，练习递归（迭代更好，这里只是为了练习递归）
*/

#include <stdio.h>

#define ARRLEN 20

void initArr(int *p, int len);
int fibonacci(unsigned int n);
int erfenfa(int *p, int low, int high, int find);

int main(void)
{
    int arr[ARRLEN], search;
    initArr(arr, ARRLEN);

    for (size_t i = 0; i < ARRLEN; i++)
    {
        printf("%d[%d]-", arr[i], i);
    }
    printf("\b \n");

    printf("please input a number u want to find: ");
    scanf("%d", &search);

    printf("your input is %d at %d.\n", search, erfenfa(arr, 0, ARRLEN, search));

    return (0);
}

void initArr(int *p, int len)
{
    for (size_t i = 0; i < len; i++)
    {
        *(p + i) = fibonacci(i);
    }
}

int fibonacci(unsigned int n)
{
    if (n < 2)
        return n == 0 ? 0 : 1;

    return fibonacci(n - 1) + fibonacci(n - 2);
}

int erfenfa(int *p, int low, int high, int find)
{
    int mid = (low + high) / 2;
    if (*(p + mid) == find)
        return mid;
    else if (low >= high)
        return -1;
    else if (*(p + mid) > find)
    {
        erfenfa(p, low, mid - 1, find);
    }
    else
    {
        erfenfa(p, mid + 1, high, find);
    }
}