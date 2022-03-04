// Program 15.3 Using inherited protected members in a derived class  
// File: prog15_03.cpp  
#include <iostream>
#include "Box.h"                                       // For the Box class
#include "Carton.h"                                    // For the Carton class
using std::cout;
using std::endl;

int main() {
  // Create a Box and two Carton objects
  Box myBox(40.0, 30.0, 20.0);
  Carton myCarton;

  cout << endl;  
  cout << "myCarton volume is " << myCarton.volume()  << endl;
// Uncomment either of the following two statement for error
//cout << "myBox volume is "    << myBox.volume()     << endl; 
//cout << "myCarton length is " << myCarton.length    << endl; 

  return 0;
}
