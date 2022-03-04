// Exercise 12.3 Integer.cpp
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

Integer* Integer::add(const Integer& obj){ 
  n += obj.n;
  return this;
}

Integer* Integer::subtract(const Integer& obj) {
  n -= obj.n;
  return this;
}

Integer* Integer::multiply(const Integer& obj) {
  n *= obj.n;
  return this;
}

void Integer::show() {
  cout << "Value is " << n << endl;
}

// Compare function
/*
int Integer::compare(const Integer obj) const {
  if(n < obj.n)
    return -1;
  else if(n==obj.n)
    return 0;
  return 1;
}
*/

// Compare function with reference parameter
// /*
int Integer::compare(const Integer& obj) const {
  if(n < obj.n)
    return -1;
  else if(n==obj.n)
    return 0;
  return 1;
}
// */