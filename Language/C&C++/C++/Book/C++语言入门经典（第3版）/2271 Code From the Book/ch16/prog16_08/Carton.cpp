// Carton.cpp
#include "Carton.h"
#include <iostream>

Carton::Carton(double lv, double wv, double hv, string material) : Box(lv, wv, hv) {
  pMaterial = new string(material);
}

Carton::Carton(const Carton& aCarton) {
  length = aCarton.length;
  width = aCarton.width;
  height = aCarton.height;
  pMaterial = new string(*aCarton.pMaterial);
}

Carton::~Carton() {
  std::cout << "Carton destructor" << std::endl;
  delete pMaterial;
}

double Carton::volume() const {
  double vol = (length - 0.5) * (width - 0.5) * (height - 0.5);
  return vol > 0.0 ? vol : 0.0;
}
