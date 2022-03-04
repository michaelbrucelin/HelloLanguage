// Box.cpp
#include <iostream>
#include "Box.h"
using std::cout;
using std::endl;

// Constructor
Box::Box(double lv, double wv, double hv) :
                                         length(lv), width(wv), height(hv){}

// Destructor
Box::~Box() {}

// Function to show the volume of an object
void Box::showVolume() const {
  cout << endl << "Box usable volume is " << volume();
}

// Function to calculate the volume of a Box object
double Box::volume() const {
  return length * width * height;
}

// Friend operator function for Box
std::ostream& operator<<(std::ostream& out, const Box& rBox) {
  return out << ' ' << rBox.length << ' ' << rBox.width << ' ' << rBox.height;
}
