// Program 12.9 Trying object sizes   File: prog12_09.cpp
#include <iostream>
#include "SizeBox.h"

using std::cout;
using std::endl;

int main() {
  SizeBox box;
  SizeBox boxes[10];
  cout << endl            << "The data members of a Box object occupy "
       << box.totalSize() << " bytes.";

  cout << endl           << "A single Box object occupies "
       << sizeof SizeBox << " bytes.";

  cout << endl           << "An array of 10 Box objects occupies "
       << sizeof(boxes)  << " bytes."
       << endl;
  return 0;
}
