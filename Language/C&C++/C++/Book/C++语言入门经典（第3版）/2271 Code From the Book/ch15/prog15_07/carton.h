// Carton.h - defines the Carton class with the Box class as base
#ifndef CARTON_H
#define CARTON_H 
#include "Box.h"                           // For Box class definition

class Carton : public Box {
  public:
    // Constructor explicitly calling the base constructor
    Carton(double lv = 1, double wv = 1, double hv = 1,  
           const char* pStr = "Cardboard",
           double dense = 0.125, double thick = 0.2);

    ~Carton();                             // Destructor

    double getWeight() const;              // "Get carton weight" function

  protected:
    char* pMaterial;                       // Carton material
    double thickness;                      // Material thickness inches
    double density;                        // Material density in pounds/cubic inch
};
#endif
