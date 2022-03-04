// Exercise 14.3 Using the subscript operator to reference characters.
// Two more prototypes are added to the MyString class declaration
// declaring the subscript operator functions for const and non-const objects

#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;
using mySpace::MyString;          // Using declaration

int main() {
  MyString s1("The fifth character is f");
  cout << "\n s1 is: ";
  s1.show();
  cout << "\nThe fifth character in s1 is: " << s1[4];

  cout << "\n\nChanging the fifth character of s1 to z...";
  s1[4] = 'z';
  s1.show();

  cout << "\n\nChanging half the characters of s1 to x...";
  for(int i = 0 ; i<s1.length()/2 ; i++)
    s1[i] = 'x';
  s1.show();
  
  // Demonstrate no subscripting allowed for const MyString objects
  const MyString s2("I am immutable");
  // Uncomment the following statement for an error.
  //s2[4] = 'z';

  cout << endl;

  return 0;
}