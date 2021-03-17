#include <iostream>
#include "./060-header.h"

unsigned short thatNum = 8;
bool printMe = true;

unsigned long returnFactorial(unsigned short num)
{
    unsigned long sum = 1;

    for (size_t i = 1; i <= num; i++)
    {
        sum *= i;
    }

    if (printMe)
        return sum;
    else
        return 0;
}