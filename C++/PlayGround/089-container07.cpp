#include <iostream>
#include "089-MyInteger.h"
using std::cout;
using std::endl;

//创建自己的迭代器

int main()
{
    Integer begin(3);
    Integer end(7);
    cout << "Today's integers are: ";
    for (; begin != end; ++begin)
        cout << *begin << " ";
    cout << endl;

    return 0;
}