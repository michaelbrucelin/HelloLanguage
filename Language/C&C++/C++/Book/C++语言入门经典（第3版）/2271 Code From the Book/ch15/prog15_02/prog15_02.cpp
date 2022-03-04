// Program 15.2 Using a function inherited from a base class File: prog15_02.cpp
#include <iostream>
#include "Box.h"                  // For the Box class
#include "Carton.h"               // For the Carton class
using std::cout;
using std::endl;

int main() {
  // Create a Box and two Carton objects
  Box myBox(40.0, 30.0, 20.0);
  Carton myCarton;
  Carton candyCarton("Thin cardboard");

  cout << endl;
  cout << "myBox volume is "       << myBox.volume()       << endl;
  cout << "myCarton volume is "    << myCarton.volume()    << endl;
  cout << "candyCarton volume is " << candyCarton.volume() << endl;
  return 0;
}
