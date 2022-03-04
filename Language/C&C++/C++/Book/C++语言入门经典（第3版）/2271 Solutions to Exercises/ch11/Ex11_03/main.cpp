// Exercise 11.3 Exercising SharedData - main.cpp
#include "shareddata.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  int number = 99;
  long lNumber = 9999999L;
  double value = 1.7320508;
  float pi = 3.142f;
  SharedData shared = { 0.1 };  // Initially a double
  shared.show();

  // Now try all four pointers
  shared.piData = &number;      
  shared.type = pInt;
  shared.show();

  shared.plData = &lNumber;
  shared.type = pLong;
  shared.show();

  shared.pdData = &value;
  shared.type = pDouble;
  shared.show();

  shared.pfData = &pi;
  shared.type = pFloat;
  shared.show();

  return 0;
}