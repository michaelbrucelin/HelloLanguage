// Exercise 14.4 Overloading the comparison operators in the MyString class.
// Four more prototypes are added to the MyString class declaration
// declaring the comparison operator functions.

#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;
using mySpace::MyString;          // Using declaration

int main() {
  MyString s1("Bent");
  MyString s2("Abu ");
  MyString s3("Ben ");
  MyString s4(s1);

  cout << "\nStrings s1, s2, s3, s4, in sequence, are: ";
  s1.show();
  s2.show();
  s3.show();
  s4.show();
  cout << "\ns1 is " << ((s1 == s2) ? "": "not ") << "equal to s2.";
  cout << "\ns1 is " << ((s1 != s3) ? "not ": "") << "equal to s3.";
  cout << "\ns3 is " << ((s3 == s4) ? "": "not ") << "equal to s4.";
  cout << "\ns1 is " << ((s1 < s2) ? "": "not ") << "less than s2.";
  cout << "\ns2 is " << ((s2 > s3) ? "": "not ") << "greater than s2.";

  cout << endl;
  return 0;
}