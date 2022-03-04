// Integer.h Integer class definition
#ifndef INTEGER_H
#define INTEGER_H
#include <iostream>
using std::cout;
using std::endl;
using std::iterator;

class Integer : public iterator<std::random_access_iterator_tag, int, int, int*, int> {
  public:
    Integer(int n=0) : x(n) {}              // Default constructor
    Integer(const Integer& y) : x(y.x) {}   // Copy constructor
    ~Integer() {}                           // Destructor

    Integer& operator=(const Integer& y) {  // Assignment operator
      x = y.x;
      return *this;
    }

    // Relational operators
    bool operator==(const Integer& y) const { return x == y.x; }
    bool operator!=(const Integer& y) const { return !(*this == y); } 
                                                        // Delegate to operator==
    bool operator<(const Integer& y)  const { return x < y.x; }

    int operator*() const { return x; }
    int operator[](int n) const { return x+n; }

    // Bidirectional operators
    Integer& operator++() {
      ++x;
      return *this;
    }

    Integer& operator--() {
      --x;
      return *this;
    }

    Integer& operator++(int) {
      Integer temp(*this);
      ++x;
      return temp;
    }

    Integer& operator--(int) {
      Integer temp(*this);
      --x;
      return temp;
    }

    // Random access operators
    Integer operator+(int n) const { return Integer (x+n); }
    Integer operator-(int n) const { return Integer (x-n); }

  private: 
    int x;
};
#endif  // INTEGER_H
