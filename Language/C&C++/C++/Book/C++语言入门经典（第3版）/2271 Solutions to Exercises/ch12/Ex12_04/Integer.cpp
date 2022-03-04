// Exercise 12.4 Integer.cpp

#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

// Copy constructor
Integer::Integer(Integer& obj): n(obj.n) {
  cout << "Object created by copy constructor." << endl;
}

// Constructor
Integer::Integer(int m): n(m) {
  cout << "Object created." << endl;
}

void Integer::show() {
  cout << "Value is " << n << endl;
}