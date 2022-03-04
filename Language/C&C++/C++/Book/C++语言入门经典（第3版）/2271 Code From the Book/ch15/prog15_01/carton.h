// Carton.h - defines the Carton class with the Box class as base
#ifndef CARTON_H
#define CARTON_H 
#include "Box.h"                                // For Box class definition

class Carton : public Box {
  public:
    Carton(const char* pStr = "Cardboard");     // Constructor
    
    ~Carton();                                  // Destructor
      
  private:
    char* pMaterial;
};
#endif 
