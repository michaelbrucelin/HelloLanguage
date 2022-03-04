// Exercise 15.2 The who() function for the base class has the protected access specifier,
// so we ensure the derived classes allow public access to the who() function. 

#include "Animal.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  Lion myLion("Leo", 400);
  Aardvark myAardvark("Algernon", 50);
  myLion.who();
  myAardvark.who();
  cout << endl;
  return 0;
}