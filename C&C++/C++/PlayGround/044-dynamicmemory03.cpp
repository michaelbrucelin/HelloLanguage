#include <iostream>

//函数返回内存的指针

int *newint(int value);

int main(void)
{
    int *x = newint(32);

    std::cout << *x << std::endl;

    delete x; //释放内存
    x = NULL;

    return (0);
}

int *newint(int value)
{
    int *thisint = new int;
    *thisint = value;

    return thisint;
}