// Carton.h
#ifndef CARTON_H
#define CARTON_H

#include <string>
#include "Box.h"
using std::string;

class Carton : public Box {
  public:
    // Constructor explicitly calling the base constructor
    Carton(double lv, double wv, double hv, string material = "Cardboard");

    // Copy constructor
    Carton(const Carton& aCarton);

    // Destructor
    ~Carton();

    // Function to calculate the volume of a Carton object
    virtual double volume(const int i = 50) const;
  private:
    string* pMaterial;
};

#endif
