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

// Function to compare two Box objects
// If the current Box is greater than the argument, 1 is returned
// If they are equal, 0 is returned
// If the current Box is less than the argument, –1 is returned
int Box::compareVolume(Box& otherBox) {
  double vol1 = this->volume();        // Get current Box volume
  double vol2 = otherBox.volume();     // Get argument volume
  return vol1 > vol2 ? 1 : (vol1 < vol2 ? -1 : 0);
}
