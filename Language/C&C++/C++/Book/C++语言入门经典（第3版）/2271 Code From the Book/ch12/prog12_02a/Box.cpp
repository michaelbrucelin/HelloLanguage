// Box.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

// Constructor definition
Box::Box(double lengthValue, double widthValue, double heightValue) {
  cout << "Box constructor called" << endl;
  length = lengthValue;
  width = widthValue;
  height = heightValue;
}

// Function to calculate the volume of a box
double Box::volume() {
  return length * width * height;
}
