// Carton.cpp
#include "Carton.h"
#include <cstring>
#include <iostream>
using std::cout;
using std::endl;

// Constructor
Carton::Carton(const char* pStr) {
  cout << "Carton constructor" << endl;
  pMaterial = new char[strlen(pStr)+1];     // Allocate space for the string
  std::strcpy( pMaterial, pStr);            // Copy it
}

// Destructor
Carton::~Carton() {
  delete[] pMaterial; 
}
