// Program 20.7 Using the Integer iterator class  File: prog20_07.cpp
#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

int main() {
  Integer begin(3);
  Integer end(7);
  cout << "Today's integers are: ";
  for( ; begin != end ; ++begin) 
    cout << *begin << " ";
  cout << endl;
  return 0;
}
// Program 20.7 Simple integer iterator class  File: prog20_07.cpp
#include <iostream>
using std::cout;
using std::endl;

class Integer {
  public:
    Integer (int arg = 0) : x(arg) {}

    bool operator!=(const Integer& arg) const {      // Comparison !=
      if (x == arg.x)                                // Debugging output
        cout << endl 
             << "operator!= returns false" << endl;  // Just to show that we are here  
      return x != arg.x;
    }

    int operator*() const { return x; }              // De-reference operator

    Integer& operator++() {                          // Prefix increment operator
      ++x;
      return *this;
    }

  private: 
    int x;
};

int main() {
  Integer begin(3);
  Integer end(7);
  cout << "Today's integers are: ";
  for( ; begin != end ; ++begin) 
    cout << *begin << " ";
  cout << endl;
  return 0;
}
