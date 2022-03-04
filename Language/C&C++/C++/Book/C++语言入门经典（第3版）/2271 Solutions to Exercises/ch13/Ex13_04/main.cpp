// Exercise 13.4 Creating and Testing the MyString class - main.cpp
#include "MyString.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  mySpace::MyString proverb("Too many cooks spoil the broth.");

  char word[] = "cook";
  int position = proverb.find("cook");

  // Search for a c-style string
  cout << "\nThe word '" << word;
  if(position < 0)
    cout << "' was not found in:";
  else
    cout << "' appears starting at position " << position << " in:";
  proverb.show();

  // Search for a character
  char ch = 'p';
  position = proverb.find(ch);
  cout << "\n\nThe character '" << ch; 
  if(position < 0)
    cout << "' was not found in:";
  else
    cout << "' appears at position " << position << " in:";
  proverb.show();

  // check other ways of creating MyString objects
  mySpace::MyString number(22);
  mySpace::MyString value("value = 22");
  mySpace::MyString repeated('2', 10);
  repeated.show();

  cout << "\nLength of string is " << repeated.length();  // Display the length

  // Search for MyString Substrings in MyString objects
  position = value.find(number);
  cout << "\n\nThe string:";
  number.show();
  if(position < 0)
    cout << "\n was not found in:";
  else
    cout << "\nappears at position " << position << " in:";
  value.show();

  position = repeated.find(number);
  cout << "\n\nThe string:";
  number.show();
  if(position < 0)
    cout << "\n was not found in:";
  else
    cout << "\nappears at position " << position << " in:";
  repeated.show();
  cout << endl;

  return 0;
}