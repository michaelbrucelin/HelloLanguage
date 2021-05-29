#include <iostream>

using std::cout;
using std::endl;

//函数模板，类似于C#中的泛型函数

template <class T>
T larger(T a, T b);

int main()
{
    cout << endl;
    cout << "Larger of 1.5 and 2.5 is " << larger(1.5, 2.5) << endl;
    cout << "Larger of 3.5 and 4.5 is " << larger(3.5, 4.5) << endl;

    int a_int = 35;
    int b_int = 45;
    cout << "Larger of " << a_int << " and " << b_int << " is " << larger(a_int, b_int) << endl;

    long a_long = 9;
    long b_long = 8;
    cout << "Larger of " << a_long << " and " << b_long << " is " << larger(a_long, b_long) << endl;

    //可以显示指定函数模板需要使用的类型
    cout << "Larger of " << a_long << " and " << a_int << " is " << larger<long>(a_long, a_int) << endl;

    return 0;
}

template <class T>
T larger(T a, T b)
{
    return a > b ? a : b;
}