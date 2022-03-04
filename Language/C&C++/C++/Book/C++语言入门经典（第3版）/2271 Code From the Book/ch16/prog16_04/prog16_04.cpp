// Program 16.4 Default parameter values in virtual functions File : prog16_04.cpp
#include <iostream>
#include "Box.h"                                    // For the Box class
#include "ToughPack.h"                              // For the ToughPack class
#include "Carton.h"	                                 // For the Carton class
using std::cout;
using std::endl;

int main() {
  Box myBox(20.0, 30.0, 40.0);                      // Declare a base box
  ToughPack hardcase(20.0, 30.0, 40.0);             // Declare derived box - same size
  Carton aCarton(20.0, 30.0, 40.0);                 // A different kind of derived box

  cout << endl;
  myBox.showVolume();                               // Display volume of base box
  hardcase.showVolume();                            // Display volume of derived box
  aCarton.showVolume();                             // Display volume of derived box
  cout << endl;

  cout << "hardcase volume is " << hardcase.volume() << endl; 

  // Now try using a base pointer for the Box object
  Box* pBox = &myBox;                               // Points to type Box
  cout << "myBox volume through pBox is " << pBox->volume() << endl;
  pBox->showVolume();
  cout << endl;

  // Now try using a base pointer for the ToughPack object
  pBox = &hardcase;                                 // Points to type ToughPack
  cout << "hardcase volume through pBox is " << pBox->volume() << endl;
  pBox->showVolume();
  cout << endl;

  // Now try using a base pointer for the Carton object
  pBox = &aCarton;                                  // Points to type Carton
  cout << "aCarton volume through pBox is " << pBox->volume() << endl;
  pBox->showVolume();

  return 0;
}
