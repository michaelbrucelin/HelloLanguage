#include <iostream>

//实现复数加法，使用对运算符+重载的话
//运算符函数作为类的成员函数

class Complex
{
public:
    Complex();
    Complex(double r, double i);

    Complex operator+(Complex &d); //对运算符+进行重载
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

Complex Complex::operator+(Complex &d) //对运算符+进行重载的实现
{
    Complex c;
    c.real = real + d.real;
    c.imag = imag + d.imag;

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