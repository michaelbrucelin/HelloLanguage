// Box.cpp
#include "Box.h"

// Box constructor
Box::Box(double aLength, double aWidth, double aHeight):
        length(aLength), width(aWidth), height(aHeight) {}

// Calculate Box volume
double Box::volume() const { 
  return length*width*height; 
}        

// getXXX() functions
double Box::getLength()  const { return length; }
double Box::getWidth() const { return width; }
double Box::getHeight()  const { return height; }
