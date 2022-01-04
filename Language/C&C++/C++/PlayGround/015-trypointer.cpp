#include <iostream>

int main(void)
{
    int a = 123;
    float b = 3.14;
    char c = 'C';
    unsigned long d = 19880808;
    std::string e = "I love 56887.";

    std::cout << "a 的值是：" << a << "\n";
    std::cout << "b 的值是：" << b << "\n";
    std::cout << "c 的值是：" << c << "\n";
    std::cout << "d 的值是：" << d << "\n";
    std::cout << "e 的值是：" << e << "\n\n";

    int *aptr = &a;
    float *bptr = &b;
    char *cptr = &c;
    unsigned long *dptr = &d;
    std::string *eptr = &e;

    *aptr = 456;
    *bptr = 2.72;
    *cptr = 'D';
    *dptr = 20201206;
    *eptr = "I love xy.";

    std::cout << "a 的值是：" << a << "\n";
    std::cout << "b 的值是：" << b << "\n";
    std::cout << "c 的值是：" << c << "\n";
    std::cout << "d 的值是：" << d << "\n";
    std::cout << "e 的值是：" << e << "\n";

    return (0);
}