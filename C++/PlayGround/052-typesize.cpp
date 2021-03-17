#include <iostream>

using std::cout;
using std::endl;

int main()
{
    // Output the sizes for integer types
    cout << endl
         << "Size of type char\tis " << sizeof(char);
    cout << endl
         << "Size of type short\tis " << sizeof(short);
    cout << endl
         << "Size of type int\tis " << sizeof(int);
    cout << endl
         << "Size of type long\tis " << sizeof(long);

    // Output the sizes for floating point types
    cout << endl
         << "Size of type float\tis " << sizeof(float);
    cout << endl
         << "Size of type double\tis " << sizeof(double);
    cout << endl
         << "Size of type long double\tis " << sizeof(long double);
    cout << endl;

    return 0;
}