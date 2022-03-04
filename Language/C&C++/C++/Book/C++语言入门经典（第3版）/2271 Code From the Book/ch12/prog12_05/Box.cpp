// Box.cpp Box class member function definitions
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

// Constructor
Box::Box(double lvalue, double wvalue, double hvalue) :
                          length(lvalue), width(wvalue), height(hvalue) {
  cout << "Box constructor called" << endl;

  // Ensure positive dimensions
  if(length <= 0.0)
    length = 1.0;
  if(width <= 0.0)
    width = 1.0;
  if(height <= 0.0)
    height = 1.0;
}

// Function to calculate the volume of a box
double Box::volume() {
  return length * width * height;
}
