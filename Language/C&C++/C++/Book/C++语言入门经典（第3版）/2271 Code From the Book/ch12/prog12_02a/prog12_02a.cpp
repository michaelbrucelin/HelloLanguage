// Program 12.2a Using a class constructor     File: prog12_02a.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

int main() {
  Box firstBox(80.0, 50.0, 40.0);

  // Calculate the volume of the box
  double firstBoxVolume = firstBox.volume();
  cout << endl;
  cout << "Size of first Box object is "
       << firstBox.length  << " by "
       << firstBox.width << " by "
       << firstBox.height
       << endl;
  cout << "Volume of first Box object is " << firstBoxVolume
       << endl;

  return 0;
}
