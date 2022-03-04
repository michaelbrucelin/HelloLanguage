// Program 16.9 Using a pointer to a data member  File: prog16_09.cpp
#include <iostream>
#include "Box.h"                                   // For the Box class
#include "ToughPack.h"                             // For the ToughPack class
#include "Carton.h"                                // For the Carton class
using std::cout;
using std::endl;

typedef double Box::* pBoxMember;                  // Define pointer to data member type

int main() {
  Box myBox(20.0, 30.0, 40.0);                     // Declare a base box
  ToughPack hardcase(35.0, 45.0, 55.0);            // Declare a derived box 
  Carton aCarton(48.0, 58.0, 68.0);                // A different kind of derived box

  pBoxMember pData = &Box::length;                 // Define pointer to Box data member

  cout << endl;

  // Using a pointer to class data member with class objects
  cout << "length member of myBox is " << myBox.*pData << endl;
  pData = &Box::width;

  cout << "width member of myBox is " << myBox.*pData << endl;
  pData = &Box::height;

  cout << "height member of myBox is " << myBox.*pData << endl;
  cout << "height member of hardcase is " << hardcase.*pData << endl;
  cout << "height member of aCarton is " << aCarton.*pData << endl;

  Box* pBox = &myBox;                               // Define pointer to Box

  // Using a pointer to class data member with a pointer to the base class
  cout << "height member of myBox is " << pBox->*pData << endl;
  pBox = &hardcase;
  cout << "height member of hardcase is " << pBox->*pData << endl;

  cout << endl;
  return 0;
}
