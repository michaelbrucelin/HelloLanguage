// ToughPack.cpp
#include "ToughPack.h"
#include <iostream>
using std::cout;
using std::endl;

ToughPack::ToughPack(double lVal, double wVal, double hVal) : 
                                                  Box(lVal, wVal, hVal) {}

double ToughPack::volume(const int i) const {
  cout << "Parameter = " << i << endl;
  return 0.85 * length * width * height;
}
