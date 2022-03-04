// Exercise 15.1 Exercising the Animal classes
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