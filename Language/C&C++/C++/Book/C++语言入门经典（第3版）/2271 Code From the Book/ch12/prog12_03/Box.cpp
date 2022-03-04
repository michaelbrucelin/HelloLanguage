// Box.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

// Default constructor definition
Box::Box() {
  cout << "Default constructor called" << endl;
  length = width = height = 1.0;          // Default dimensions
}

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
