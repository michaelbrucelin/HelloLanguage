#ifndef INTEGER_H
#define INTEGER_H
#include <iostream>
using std::cout;
using std::endl;

class Integer
{
public:
    Integer(int arg = 0) : x(arg) {}

    bool operator!=(const Integer &arg) const
    {                   // Comparison !=
        if (x == arg.x) // Debugging output
            cout << endl
                 << "operator!= returns false"
                 << endl; // Just to show that we are here

        return x != arg.x;
    }

    int operator*() const { return x; } // De-reference operator

    Integer &operator++()
    { // Prefix increment operator
        ++x;

        return *this;
    }

private:
    int x;
};
#endif // INTEGER_H