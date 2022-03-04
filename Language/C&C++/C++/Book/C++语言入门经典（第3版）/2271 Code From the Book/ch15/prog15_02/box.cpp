// Box.cpp Implementation of the Box class
#include "box.h"
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Box::Box(double lv, double wv, double hv) : length(lv), width(wv), height(hv) {
  cout << "Box constructor" << endl;
}

// Function to calculate the volume of a Box object
double Box::volume() const { 
  return length*width*height;
}
