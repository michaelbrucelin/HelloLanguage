#include <iostream>
#include <iterator>
#include <algorithm>
#include "091-MyInteger.h"
using std::cout;
using std::endl;

int main()
{
    Integer F1(-1);
    Integer L1(10);
    cout << "The values [-1..10) in forward order: " << endl;
    copy(F1, L1, std::ostream_iterator<int>(cout, " "));
    cout << endl;

    typedef std::reverse_iterator<Integer> CountDown;
    CountDown F2(10);
    CountDown L2(-1);
    cout << "the values (10..-1] in reverse order: " << endl;
    copy(F2, L2, std::ostream_iterator<int>(cout, " "));
    cout << endl;

    return 0;
}