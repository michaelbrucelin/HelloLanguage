// Box.cpp
#include "Box.h"
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Box::Box(double lvalue, double wvalue, double hvalue) :
                    length(lvalue), width(wvalue), height(hvalue) {}

double Box::volume() const {
  return length * width * height;
}

Box::~Box() {
  cout << "Box destructor" << endl;
}