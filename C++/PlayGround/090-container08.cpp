#include <iostream>
#include "090-MyInteger.h"
using std::cout;
using std::endl;

//给average<>传送Integer对象

template <typename Iter>
double average(Iter a, Iter end)
{
    double sum = 0.0;
    int count = 0;
    for (; a != end; ++count)
        sum += *a++;

    return sum / count; // Lets bad things happen when count==0
}

int main()
{
    Integer first(1);
    Integer last(11);
    cout << "The average of the integers from " << *first << " to " << *last - 1;
    cout << " is " << average(first, last) << endl;

    return 0;
}