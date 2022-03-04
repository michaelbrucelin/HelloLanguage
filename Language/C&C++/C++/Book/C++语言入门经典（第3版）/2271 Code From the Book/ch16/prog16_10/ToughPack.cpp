// ToughPack.cpp
#include "ToughPack.h"

ToughPack::ToughPack(double lVal, double wVal, double hVal) : Box(lVal, wVal, hVal){}

double ToughPack::volume() const {
  return 0.85 * length * width * height;
}