// Rational.h
// Create by mlin

// 这个头文件声明了有理数类（Rational Class）
// 类内部对四则运算进行了重载，实现了分数的四则运算
// 此头文件只有声明，没有实现

#ifndef RATIONAL_H //通过预编译的形式，防止此头文件被include多次

#define RATIONAL_H

namespace myMath
{

#include <iostream>

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

        friend std::ostream &operator<<(std::ostream &os, Rational r); //由于<<操作符不是Rational类的，所以只能使用友元函数来实现
    };
} // namespace myMath

#endif

/*
头文件，系统头文件放在<>，自定义头文件放在""
可以用头文件来保存程序任何一段代码，如函数或类的声明，但一定不要用头文件夹保存它们的实现
头文件里应该使用更多的注释
如果没有给出路径名，编译器将到当前子目录以及当前开发环境中的其他逻辑子目录里去寻找头文件
*/