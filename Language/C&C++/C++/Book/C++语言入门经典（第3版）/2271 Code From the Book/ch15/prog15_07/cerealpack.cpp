// Cerealpack.cpp
#include <iostream>
#include "Carton.h"
#include "Contents.h"
#include "Cerealpack.h"
using std::cout;
using std::endl;

// Constructor
CerealPack::CerealPack(double length, double width, double height,
                                                       const char* cerealType):
             Carton(length, width, height, "cardboard"), Contents(cerealType) {
  cout << "CerealPack constructor" << endl; 
  Contents::volume = 0.9*Carton::volume();         // Set contents volume
}

// Destructor
CerealPack::~CerealPack() {
  cout << "CerealPack destructor" << endl; 
}
