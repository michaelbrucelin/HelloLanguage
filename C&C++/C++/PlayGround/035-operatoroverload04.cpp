#include <iostream>
#include <stdlib.h>
#include <string>

//运算符重载实现分数的加减乘除

class Rational
{
public:
    Rational(int num, int demon); // num=分子, denom=分母

    Rational operator+(Rational rhs); //rhs==right hand side
    Rational operator-(Rational rhs);
    Rational operator*(Rational rhs);
    Rational operator/(Rational rhs);

    void print();

private:
    void normalize(); //负责对分数简化处理

    int numerator;   //分子
    int denominator; //分母
};

Rational::Rational(int num, int denom)
{
    numerator = num;
    denominator = denom;

    normalize();
}

//normalize()负责对分数进行简化操作包括：
//1. 只允许分子为负数，如果分母为负数，则把负数移到分子部分，如1/-2==-1/2
//2. 利用欧几里得算法（辗转相除法）将分数进行简化，如2/10=>1/5
void Rational::normalize()
{
    //确保分母为正数
    if (denominator < 0)
    {
        numerator = -numerator;
        denominator = -denominator;
    }

    //欧几里得算法
    int a = abs(numerator);
    int b = abs(denominator);
    //求最大公约数
    while (b > 0)
    {
        int t = a % b;
        a = b;
        b = t;
    }

    //分子分母分别除以最大公约数得到简化的分数
    numerator /= a;
    denominator /= a;
}

//加法运算符的重载
//a   c   a*d   c*b   a*d + c*b
//- + - = --- + --- = ---------
//b   d   b*d   b*d      b*d
Rational Rational::operator+(Rational rhs)
{
    int a = numerator;
    int b = denominator;
    int c = rhs.numerator;
    int d = rhs.denominator;

    int e = a * b + c * d;
    int f = b * d;

    return Rational(e, f);
}

//减法运算符的重载
//a   c   a   -c
//- - - = - + -
//b   d   b   d
Rational Rational::operator-(Rational rhs)
{
    rhs.numerator = -rhs.numerator;

    return operator+(rhs);
}

//乘法运算符的重载
//a   c   a*c
//- * - = ---
//b   d   b*d
Rational Rational::operator*(Rational rhs)
{
    int a = numerator;
    int b = denominator;
    int c = rhs.numerator;
    int d = rhs.denominator;

    int e = a * c;
    int f = b * d;

    return Rational(e, f);
}

//除法运算符的重载
//a   c   a   d
//- / - = - * -
//b   d   b   c
Rational Rational::operator/(Rational rhs)
{
    int t = rhs.numerator;
    rhs.numerator = rhs.denominator;
    rhs.denominator = t;

    return operator*(rhs);
}

void Rational::print()
{
    if (numerator % denominator == 0)
        std::cout << numerator / denominator;
    else
        std::cout << numerator << "/" << denominator;
}

int main(void)
{
    Rational f1(2, 16);
    Rational f2(7, 8);

    //测试有理数的加法运算
    Rational res = f1 + f2;
    f1.print();
    std::cout << " + ";
    f2.print();
    std::cout << " = ";
    res.print();
    std::cout << std::endl;

    //测试有理数的减法运算
    res = f1 - f2;
    f1.print();
    std::cout << " - ";
    f2.print();
    std::cout << " = ";
    res.print();
    std::cout << std::endl;

    //测试有理数的乘法运算
    res = f1 * f2;
    f1.print();
    std::cout << " * ";
    f2.print();
    std::cout << " = ";
    res.print();
    std::cout << std::endl;

    //测试有理数的除法运算
    res = f1 / f2;
    f1.print();
    std::cout << " / ";
    f2.print();
    std::cout << " = ";
    res.print();
    std::cout << std::endl;

    return (0);
}