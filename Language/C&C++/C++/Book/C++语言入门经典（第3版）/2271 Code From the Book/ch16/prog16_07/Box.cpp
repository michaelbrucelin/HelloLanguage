// Box.cpp
#include "Box.h"

Box::Box(double lvalue, double wvalue, double hvalue) :
                                  length(lvalue), width(wvalue), height(hvalue) {}

double Box::volume() const {
  return length * width * height;
}
