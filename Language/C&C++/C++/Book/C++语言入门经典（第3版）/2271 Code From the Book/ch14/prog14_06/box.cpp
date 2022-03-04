// Box.cpp
#include "Box.h"

// Box constructor
Box::Box(double aLength, double aWidth, double aHeight) {
  double maxSide = aLength > aWidth ? aLength : aWidth;
  double minSide = aLength < aWidth ? aLength : aWidth;
  length = maxSide > 0.0 ? maxSide : 1.0;
  width = minSide > 0.0 ? minSide : 1.0;
  height = aHeight > 0.0 ? aHeight : 1.0;
}

// Calculate Box volume
double Box::volume() const { 
  return length*width*height; 
}        

// getXXX() functions
double Box::getLength()  const { return length; }
double Box::getWidth() const { return width; }
double Box::getHeight()  const { return height; }
