// Program 12.7 Using the this pointer   File: prog12_07.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

int main() {
  cout << endl;

  Box firstBox(17.0, 11.0, 5.0);
  Box secondBox(9.0, 18.0, 4.0);

  cout << "The first box is "
       << (firstBox.compareVolume(secondBox) >= 0 ? "" : "not ")
       << "greater than the second box."
       << endl;

  cout << "Volume of first box = "
       << firstBox.volume()
       << endl;

  cout << "Volume of second box = "
       << secondBox.volume()
       << endl;

  return 0;
}
