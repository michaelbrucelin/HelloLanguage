// Exercise 12.1 Integer.cpp

#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

Integer::Integer(int m) {
  n = m;
  cout << "Object created." << endl;
}

void Integer::show() {
  cout << "Value is " << n << endl;
}