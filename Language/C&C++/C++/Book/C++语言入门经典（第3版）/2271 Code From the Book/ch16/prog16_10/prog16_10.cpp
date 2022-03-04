// Program 16.10 Using a pointer to a function member   File: prog16_10.cpp
#include <iostream>
#include "Box.h"                                    // For the Box class
#include "ToughPack.h"                              // For the ToughPack class
#include "Carton.h"                                 // For the Carton class
using std::cout;
using std::endl;

typedef double (Box::*pBoxFunction)() const;        // Pointer to member function type

int main() {
  Box myBox(20.0, 30.0, 40.0);                      // Declare a base box
  ToughPack hardcase(35.0, 45.0, 55.0);             // Declare a derived box 
  Carton aCarton(48.0, 58.0, 68.0);                 // A different kind of derived box

  pBoxFunction pGet = &Box::getLength;              // Pointer to member function

  cout << endl;

  // Call member function for an object through the pointer
  cout << "length member of myBox is " << (myBox.*pGet)() << endl;

  pGet = &Box::getWidth;
  cout << "width member of myBox is " << (myBox.*pGet)() << endl;

  pGet = &Box::getHeight;
  cout << "height member of myBox is " << (myBox.*pGet)() << endl;

  // It works for derived class objects too
  cout << "height member of hardcase is " << (hardcase.*pGet)() << endl;
  cout << "height member of aCarton is " << (aCarton.*pGet)() << endl;

  Box* pBox = &myBox;                               // Pointer to the base class

  // Calling a function with a pointer to a class object
  cout << "height member of myBox is " << (pBox->*pGet)() << endl;

  pBox = &hardcase;
  cout << "height member of hardcase is " << (pBox->*pGet)() << endl;

  cout << endl;
  return 0;
}
