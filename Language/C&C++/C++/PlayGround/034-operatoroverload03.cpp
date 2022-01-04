#include <iostream>

//实现复数加法，使用对运算符+重载的话
//运算符函数作为类的友元函数，这样是可行的，但是会破坏类的封装完整性，不推荐使用

class Complex
{
public:
    Complex();
    Complex(double r, double i);

    friend Complex operator+(Complex &a, Complex &b); //对运算符+进行重载，使用友元函数
    void print();

private:
    double real;
    double imag;
};

Complex::Complex()
{
    real = 0;
    imag = 0;
}

Complex::Complex(double r, double i)
{
    real = r;
    imag = i;
}

//这里作为友元函数，不属于Complex，不需要写::
Complex operator+(Complex &a, Complex &b) //对运算符+进行重载的实现
{
    Complex c;
    c.real = a.real + b.real;
    c.imag = a.imag + b.imag;

    //return Complex(a.real + b.real, a.imag + b.imag);
    return c;
}

void Complex::print()
{
    std::cout << "(" << real << ", " << imag << "i)" << std::endl;
}

int main(void)
{
    Complex c1(3, 4), c2(5, -10), c3;
    c3 = c1 + c2;

    std::cout << "c1 = ";
    c1.print();
    std::cout << "c2 = ";
    c2.print();
    std::cout << "c1 + c2 = ";
    c3.print();

    return (0);
}