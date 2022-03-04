// Program 12.5 Creating a copy of an object    File: prog12_05.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

int main() {
  cout << endl;

  Box firstBox(2.2, 1.1, 0.5);
  Box secondBox(firstBox);

  cout << "Volume of first box = "
       << firstBox.volume()
       << endl;

  cout << "Volume of second box = "
       << secondBox.volume()
       << endl;

  return 0;
}
