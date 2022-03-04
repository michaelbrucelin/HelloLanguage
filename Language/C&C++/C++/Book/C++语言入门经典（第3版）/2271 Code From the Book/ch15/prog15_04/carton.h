// Carton.h - defines the Carton class with the Box class as base
#ifndef CARTON_H
#define CARTON_H 
#include "Box.h"                                // For Box class definition

class Carton : public Box {
  public:
    // Constructor which can also act as default constructor - calls default base constructor automatically
    Carton(const char* pStr = "Cardboard");
    
    // Constructor explicitly calling the base constructor
    Carton(double lv, double wv, double hv, const char* pStr = "Cardboard");
    
    ~Carton();                                  // Destructor

    // Function to calculate the volume of a Carton object
    double volume() const;

  protected:
    char* pMaterial;
};
#endif 
