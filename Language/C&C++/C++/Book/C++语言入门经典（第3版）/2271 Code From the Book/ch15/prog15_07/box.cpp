// Box.cpp
#include "box.h"
#include <iostream>
using std::cout;
using std::endl;

// Default constructor
Box::Box(double lv, double wv, double hv) : length(lv), width(wv), height(hv) { 
  cout << "Box constructor" << endl; 
}

// Copy constructor
Box::Box(const Box& aBox) : 
               length(aBox.length), width(aBox.width), height(aBox.height) {
  cout << "Box copy constructor called" << endl;
}

// Destructor
Box::~Box() { 
  cout << "Box destructor" << endl;
}                  

// Function to calculate the volume of a Box object
double Box::volume() const { 
  return length*width*height; 
}
