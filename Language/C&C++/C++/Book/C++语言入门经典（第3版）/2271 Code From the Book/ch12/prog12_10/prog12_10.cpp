// Program 12.10 Counting Box objects      File: prog12_10.cpp
#include <iostream>
#include "Box.h"

using std::cout;
using std::endl;

int main() {
  cout << endl;

  Box firstBox(17.0, 11.0, 5.0);
  cout << "Object count is " << firstBox.getObjectCount() << endl;
  Box boxes[5];
  cout << "Object count is " << firstBox.getObjectCount() << endl;

  cout << "Volume of first box = "
       << firstBox.volume()
       << endl;

  const int count = sizeof boxes/sizeof boxes[0];

  cout <<"The boxes array has " << count << " elements."
       << endl;
  
  cout <<"Each element occupies " << sizeof boxes[0] << " bytes."
       << endl;

  for(int i = 0 ; i < count ; i++)
    cout << "Volume of boxes[" << i << "] = "
         << boxes[i].volume()
         << endl;

  return 0;
}
