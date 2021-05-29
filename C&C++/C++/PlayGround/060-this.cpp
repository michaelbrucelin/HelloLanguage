#include <iostream>
#include "./060-header.h"

extern unsigned short thatNum;
static bool printMe = false;

int main(void)
{
    unsigned short thisNum = 10;

    std::cout << thisNum << "! is equal to " << returnFactorial(thisNum) << std::endl;
    std::cout << thatNum << "! is equal to " << returnFactorial(thatNum) << std::endl;
    std::cout << headerNum << "! is equal to " << returnFactorial(headerNum) << std::endl;

    if (printMe)
        std::cout << "好事啊！" << std::endl
                  << std::endl;

    return (0);
}