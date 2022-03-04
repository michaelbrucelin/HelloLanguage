// Box.cpp
#include "Box.h"
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Box::Box(double lvalue, double wvalue, double hvalue) :
                    length(lvalue), width(wvalue), height(hvalue) {}

// Output the volume
void Box::showVolume() const {
  cout << "Box usable volume is " << volume() << endl;
}

// Calculate the volume
double Box::volume(const int i) const {
  cout << "Parameter = " << i << endl;
  return length * width * height;
}
