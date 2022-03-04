// Program 12.3 Defining and using a default class constructor   File: prog12_03.cpp
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

  Box smallBox;
  smallBox.length = 10.0;
  smallBox.width = 5.0;
  smallBox.height = 4.0;

  // Calculate the volume of the small box
  cout << "Size of small Box object is "
       << smallBox.length << " by " 
       << smallBox.width << " by "
       << smallBox.height
       << endl;
  cout << "Volume of small Box object is " << smallBox.volume()
       << endl;

  return 0;
}
