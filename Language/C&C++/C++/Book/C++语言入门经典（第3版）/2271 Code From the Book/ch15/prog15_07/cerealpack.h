// Cerealpack.h - Class defining a carton of cereal
#ifndef CEREALPACK_H 
#define CEREALPACK_H
#include "Carton.h"
#include "Contents.h"

class CerealPack: public Carton, public Contents {
  public:
    CerealPack(double length, double width, double height, const char* cerealType); // Constructor

    ~CerealPack();                                          // Destructor
};
#endif
