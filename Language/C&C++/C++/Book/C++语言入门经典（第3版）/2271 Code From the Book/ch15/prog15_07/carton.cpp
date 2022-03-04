// Carton.cpp
#include "Carton.h"
#include <cstring>
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Carton::Carton(double lv, double wv, double hv,     
               const char* pStr, double dense, double thick):
                      Box(lv, wv, hv), density(dense), thickness(thick) {
  pMaterial = new char[strlen(pStr)+1];     // Allocate space for the string
  strcpy( pMaterial, pStr);                 // Copy it
  cout << "Carton constructor" << endl;
}

// Destructor
Carton::~Carton() {
  cout << "Carton destructor" << endl;
  delete[] pMaterial;
}

// "Get carton weight" function
double Carton::getWeight() const { 
  return 2*(length*width + width*height + height*length)*thickness*density;
}
