// Program 16.7 Using an indirect base class  File: prog16_07.cpp
#include <iostream>
#include "Box.h"                                    // For the Box class
#include "ToughPack.h"                              // For the ToughPack class
#include "Carton.h"                                 // For the Carton class
#include "Can.h"                                    // for the Can class
using std::cout;
using std::endl;

int main() {
  Box aBox(40, 30, 20);
  Can aCan(10, 3);
  Carton aCarton(40, 30, 20);
  ToughPack hardcase(40, 30, 20);

  Vessel* pVessels[] = { &aBox, &aCan, &aCarton, &hardcase };

  cout << endl;
  for(int i = 0 ; i < sizeof pVessels / sizeof(pVessels[0]) ; i++)
    cout << "Volume is " << pVessels[i]->volume() << endl;

  return 0;
}
