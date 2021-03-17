#include <iostream>
using std::cout;
using std::endl;

//函数指针，类似于C#中的委托

long sum(long a, long b);
long product(long a, long b);

int main()
{
    long (*pDo_it)(long, long) = 0; //函数指针

    pDo_it = product;
    cout << endl
         << "3*5 = " << pDo_it(3, 5); //通过函数指针调用函数

    pDo_it = sum; //函数指针指向另一个函数
    cout << endl
         << "3 * (4+5) + 6 = " << pDo_it(product(3, pDo_it(4, 5)), 6); //通过函数指针调用函数

    cout << endl;

    return 0;
}

long product(long a, long b)
{
    return a * b;
}

long sum(long a, long b)
{
    return a + b;
}