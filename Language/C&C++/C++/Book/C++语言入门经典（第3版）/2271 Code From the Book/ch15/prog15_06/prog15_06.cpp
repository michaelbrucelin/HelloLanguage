// Program 15.6 Destructors in a class hierarchy File: prog15_06.cpp
#include <iostream>
#include "Box.h"                                       // For the Box class
#include "Carton.h"                                    // For the Carton class
using std::cout;
using std::endl;

int main() {
  Carton myCarton;
  Carton candyCarton(50.0, 30.0, 20.0, "Thin cardboard");

  cout << endl << "myCarton volume is "    << myCarton.volume();
  cout << endl << "candyCarton volume is " << candyCarton.volume() 
       << endl << endl;

  return 0;
}
