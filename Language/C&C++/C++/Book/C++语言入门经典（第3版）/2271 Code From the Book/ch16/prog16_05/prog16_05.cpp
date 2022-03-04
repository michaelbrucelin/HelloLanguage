// Program 16.5 Using virtual functions through a reference to the base class
// File: prog16_05.cpp
#include <iostream>
#include "Box.h"                               // For the Box class
#include "ToughPack.h"                         // For the ToughPack class
#include "Carton.h"                            // For the Carton class
using std::cout;
using std::endl;

void showVolume(const Box& rBox);              // Prototype for global function

int main() {
  Box myBox(20.0, 30.0, 40.0);                 // Declare a base box
  ToughPack hardcase(20.0, 30.0, 40.0);        // Declare derived box - same size
  Carton aCarton(20.0, 30.0, 40.0);            // A different kind of derived box

  cout << endl;
  showVolume(myBox);                           // Display volume of base box
  showVolume(hardcase);                        // Display volume of derived box
  showVolume(aCarton);                         // Display volume of derived box

  // Lines deleted

  return 0;
}

// Global function to display the volume of a box
void showVolume(const Box& rBox) {
  rBox.showVolume();
}
