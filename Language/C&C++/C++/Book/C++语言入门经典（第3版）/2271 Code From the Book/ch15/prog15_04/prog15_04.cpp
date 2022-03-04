// Program 15.4 Calling a base class constructor from a derived class constructor
// File prog15_04.cpp
#include <iostream>
#include "Box.h"                                       // For the Box class
#include "Carton.h"                                    // For the Carton class
using std::cout;
using std::endl;

int main() {
  // Create two Carton objects
  Carton myCarton;
  Carton candyCarton(50.0, 30.0, 20.0, "Thin cardboard");

  cout << endl << "myCarton volume is "    << myCarton.volume();
  cout << endl << "candyCarton volume is " << candyCarton.volume()
       << endl;

  return 0;
}
