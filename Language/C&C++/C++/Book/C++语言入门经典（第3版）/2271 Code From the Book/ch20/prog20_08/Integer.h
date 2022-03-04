// Integer.h Integer class definition
#ifndef INTEGER_H
#define INTEGER_H
#include <iostream>
using std::cout;
using std::endl;

class Integer {
  public:
    Integer (int arg = 0) : x(arg) {}

    bool operator!=(const Integer& arg) const {  // Comparison !=
      return x != arg.x;
    }

    int operator*() const { return x; }     // De-reference operator

    Integer& operator++() {                 // Prefix increment operator
      ++x;
      return *this;
    }

      const Integer operator++(int) {         // Postfix ++ operator
      Integer temp(*this);                  // save our current value
      ++x;                                  // change to new value 
      return temp;                          // return unchanged saved value
    }

  private: 
    int x;
};
#endif  // INTEGER_H
