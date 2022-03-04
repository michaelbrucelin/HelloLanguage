// Program 11.2 Using pointers to Box objects File: prog11_02.cpp
#include <iostream>
#include "box.h"
using std::cout;
using std::endl;

int main() {
  Box aBox = { 10, 20, 30 };
  Box* pBox = &aBox;                           // Store address of aBox
  cout << endl 
       << "Volume of aBox is " << pBox->volume() << endl;

  Box* pdynBox = new Box;                      // Create Box in the free store
  pdynBox->height = pBox->height+5.0;
  pdynBox->length = pBox->length-3.0;
  pdynBox->width = pBox->width-2.0;
  cout << "Volume of Box in the free store is " << pdynBox->volume() << endl;

  delete pdynBox;
  return 0;
}
