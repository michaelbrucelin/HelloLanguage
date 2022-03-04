// Program 15.1 Defining and using a derived class  File: prog15_01.cpp
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

  // Check them out - sizes first of all
  cout << endl
       << "myBox occupies "       << sizeof myBox       << " bytes" << endl;
  cout << "myCarton occupies "    << sizeof myCarton    << " bytes" << endl;
  cout << "candyCarton occupies " << sizeof candyCarton << " bytes" << endl;

//  myBox.length = 10.0;          // uncomment this for an error

//  candyCarton.length = 10.0;    // uncomment this for an error

  return 0;
}
