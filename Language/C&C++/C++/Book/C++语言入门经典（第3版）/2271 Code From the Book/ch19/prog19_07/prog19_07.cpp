// Program 19.7 Writing Box object to cout  File: prog19_07.cpp
#include <iostream>
#include "Box.h"
using std::cout;
using std::endl;

int main() {
  Box bigBox(50, 60, 70);
  Box smallBox(2, 3, 4);
  cout << endl << "bigBox is " << bigBox;
  cout << endl << "smallBox is " << smallBox;
  cout << endl;
  return 0;
}
