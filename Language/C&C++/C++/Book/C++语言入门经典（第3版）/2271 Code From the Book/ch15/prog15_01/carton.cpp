// Carton.cpp
#include "Carton.h"
#include <cstring>

// Constructor
Carton::Carton(const char* pStr) {
  pMaterial = new char[strlen(pStr)+1];     // Allocate space for the string
  std::strcpy( pMaterial, pStr);            // Copy it
}

// Destructor
Carton::~Carton() {
  delete[] pMaterial; 
}
