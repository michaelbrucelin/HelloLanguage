// Contents.cpp
#include "contents.h"
#include <cstring>
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Contents::Contents(const char* pStr, double weight, double vol):
                                     unitweight(weight), volume(vol) {
  pName = new char[strlen(pStr)+1];
  std::strcpy(pName, pStr);
  cout << "Contents constructor" << endl;    
}

// Destructor
Contents::~Contents() {
  delete[] pName;
  cout << "Contents destructor" << endl;
}

// "Get Contents weight" function
double Contents::getWeight() const { 
  return volume*unitweight; 
}
