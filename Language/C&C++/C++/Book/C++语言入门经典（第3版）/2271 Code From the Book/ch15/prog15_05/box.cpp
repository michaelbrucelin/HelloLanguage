// Box.cpp
#include "box.h"
#include <iostream>
using std::cout;
using std::endl;

// Default constructor
Box::Box() : length(1.0), width(1.0), height(1.0) { 
  cout << "Default Box constructor" << endl; 
}

// Constructor
Box::Box(double lv, double wv, double hv) : length(lv), width(wv), height(hv) { 
  cout << "Box constructor" << endl; 
}

// Copy constructor
Box::Box(const Box& aBox) : 
                    length(aBox.length), width(aBox.width), height(aBox.height) {
  cout << "Box copy constructor called" << endl;
}
