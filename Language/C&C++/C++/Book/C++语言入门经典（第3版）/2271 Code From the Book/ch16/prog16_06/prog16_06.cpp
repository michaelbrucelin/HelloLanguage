// Program 16.6 Using an abstract base class  File: prog16_06.cpp
#include <iostream>
#include "Box.h"                                    // For the Box class
#include "ToughPack.h"                              // For the ToughPack class
#include "Carton.h"                                 // For the Carton class
using std::cout;
using std::endl;

int main() {
  cout << endl;

  ToughPack hardcase(20.0, 30.0, 40.0);
  Box* pBox = &hardcase;                            // Store address of ToughPack object
  cout << "Volume of hardcase is " << pBox->volume() << endl;

  Carton aCarton(20.0, 30.0, 40.0);
  pBox = &aCarton;                                  // Store address of a Carton object
  cout << "Volume of aCarton is " << pBox->volume() << endl;

  return 0;
}
