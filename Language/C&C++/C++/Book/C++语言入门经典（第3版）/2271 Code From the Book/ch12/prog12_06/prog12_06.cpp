// Program 12.6 Using a friend function of a class  File: prog12_06.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

int main() {
  cout << endl;

  Box firstBox(2.2, 1.1, 0.5);
  Box secondBox;
  Box* pthirdBox = new Box(15.0, 20.0, 8.0);

  cout << "Volume of first box = "
       << firstBox.volume()
       << endl;

  cout << "Surface area of first box = "
       << boxSurface(firstBox)
       << endl;

  cout << "Volume of second box = "
       << secondBox.volume()
       << endl;

  cout << "Surface area of second box = "
       << boxSurface(secondBox)
       << endl;

  cout << "Volume of third box = "
       << pthirdBox->volume()
       << endl;

  cout << "Surface area of third box = "
       << boxSurface(*pthirdBox)
       << endl;

  delete pthirdBox;
  return 0;
}

// friend function to calculate the surface area of a Box object
double boxSurface(const Box& theBox) {
  return 2.0 * (theBox.length * theBox.width +
                theBox.length * theBox.height +
                theBox.height * theBox.width);
}
