// Exercise 15.3 By addng a few lines to the test program, we can see the difference 
// between the calls to the base class and derived class who() functions. 

#include "Animal.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  Lion myLion("Leo", 400);
  Aardvark myAardvark("Algernon", 50);
  cout << "\nCalling derived versions of who():";
  myLion.who();
  myAardvark.who();

  cout << "\n\nCalling base versions of who():";
  myLion.Animal::who();
  myAardvark.Animal::who();
  cout << endl;
  return 0;
}