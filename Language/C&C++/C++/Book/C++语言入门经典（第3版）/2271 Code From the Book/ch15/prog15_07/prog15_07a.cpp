// Program 15.7a Using multiple inheritance. Compilable version!
// File: prog15_07a.cpp
#include <iostream>
#include "CerealPack.h"               // For the CerealPack class
using std::cout;
using std::endl;

int main() {
  CerealPack packOfFlakes(8.0, 3.0, 10.0, "Cornflakes");

cout << endl; 
  cout << "packOfFlakes volume is " << packOfFlakes.Carton::volume() << endl;
  cout << "packOfFlakes weight is "    
       << packOfFlakes.Carton::getWeight()+packOfFlakes.Contents::getWeight()
       << endl; 

  return 0;
}
