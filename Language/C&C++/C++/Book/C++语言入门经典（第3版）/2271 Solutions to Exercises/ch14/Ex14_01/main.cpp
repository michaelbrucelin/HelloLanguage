// Exercise 14.1 Adding an implementation of the assignment operator to the MyString class
// The MyString.h andd MyString.cpp files from Exercise 13.4 are the base for this
// The declaration for operator=() has been added to the class definition
// and the definition for the function is in the .cpp file.
// Here's a short program to test the class: 

#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;
using mySpace::MyString;          // Using declaration

int main() {
  MyString s1("Gabby Hayes");
  MyString s2("Marilyn Monroe");
  cout << "\n s1 is: ";
  s1.show();
  cout << "\n s2 is: ";
  s2.show();

  s1 = s2;                        // Try out assignment
  cout << "\n After executing s1 = s2, s1 is: ";
  s1.show();

  MyString s3("Sylvester Stallone");
  cout << "\n\n s3 is: ";
  s3.show();
  s1 = s2 = s3;                   // Try out repeated assignment
  cout << "\n After executing s1 = s2 = s3, s1 is: ";
  s1.show();
  cout << "\n and s2 is: ";
  s2.show();
  cout << endl;

  return 0;
}