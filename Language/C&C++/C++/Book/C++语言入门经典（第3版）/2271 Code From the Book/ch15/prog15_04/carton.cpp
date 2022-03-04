// Carton.cpp
#include "Carton.h"
#include <cstring>
#include <iostream>
using std::cout;
using std::endl;

// Constructor which can also act as default constructor - 
//            calls default base constructor automatically
Carton::Carton(const char* pStr) {
  pMaterial = new char[strlen(pStr)+1];     // Allocate space for the string
  std::strcpy( pMaterial, pStr);                 // Copy it
  cout << "Carton constructor 1" << endl;
}

// Constructor explicitly calling the base constructor
Carton::Carton(double lv, double wv, double hv, const char* pStr): Box(lv, wv, hv) {
  pMaterial = new char[strlen(pStr)+1];     // Allocate space for the string
  std::strcpy(pMaterial, pStr);             // Copy it
  cout << "Carton constructor 2" << endl;
}

// Destructor
Carton::~Carton() {
  delete[] pMaterial; 
}

// Function to calculate the volume of a Carton object
double Carton::volume() const { 
  return length*width*height; 
}
