// Program 12.4 Using a class with private data members   File: prog12_04.cpp 
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

//  secondBox.length = 4.0;                  // Uncomment this line to get an error

  cout << "Volume of second box = "
       << secondBox.volume()
       << endl;

  cout << "Volume of third box = "
       << pthirdBox->volume()
       << endl;

  delete pthirdBox;
  return 0;
}
