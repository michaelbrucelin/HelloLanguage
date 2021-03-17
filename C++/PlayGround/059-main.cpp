#include <iostream>
#include "./059-rational.h"

// 这个是程序的主体

//using namespace myMath;//不推荐这样使用，失去了命令空间的意义

int main(void)
{
    myMath::Rational f1(2, 16);
    myMath::Rational f2(7, 8);

    //测试有理数的加法运算
    std::cout << f1 << " + " << f2 << " = " << (f1 + f2) << std::endl;

    //测试有理数的减法运算
    std::cout << f1 << " - " << f2 << " = " << (f1 - f2) << std::endl;

    //测试有理数的乘法运算
    std::cout << f1 << " * " << f2 << " = " << (f1 * f2) << std::endl;

    //测试有理数的除法运算
    std::cout << f1 << " / " << f2 << " = " << (f1 / f2) << std::endl;

    return (0);
}