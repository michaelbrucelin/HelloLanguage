// Exercise 14.2 Concatenating and appending strings.
// We will add prototypes for overloaded + and += operators to the MyString class.
// Note that the argument and return values to the += operator functions are references.

#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;
using mySpace::MyString;          // Using declaration

int main() {
  MyString s1;
  MyString s2("Abu ");
  MyString s3("Ben ");
  cout << "\n s2 is: ";
  s2.show();
  cout << "\n s3 is: ";
  s3.show();

  s1 = s2+s3;                     // Try out addition

  cout << "\n After executing s1 = s2+s3, s1 is: ";
  s1.show();

  s3 = MyString("Adam");
  cout << "\n\n s3 is: ";
  s3.show();
  s1 += s3; 
  cout << "\n After executing s1 = s2+s3, s1 is: ";
  s1.show();

  cout << endl;

  return 0;
}