// Exercise 14.5 Overloading the function call operator in the MyString class.
// One more prototype is added to the MyString class declaration
// declaring the function call operator function.

#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;
using mySpace::MyString;          // Using declaration

int main() {
  MyString s1("Abu Ben Adam");
  cout << "\ns1 is:";
  s1.show();

  MyString s2 = s1(0,7);
  cout << "\ns1(0, 7) is:";
  s2.show();

  MyString s3= s2(4, 3);
  cout << "\ns2(4, 3) is:";
  s3.show();

  MyString s4 =s1(8, 4);
  cout << "\ns1(8, 4) is:";
  s4.show();

  cout << "\ns1(4, 8)(0, 3) is:";
  s1(4, 8)(0, 3).show();            // A substring of a substring...

  cout << endl;

  return 0;
}