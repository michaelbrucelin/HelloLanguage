// Exercise 17.4 Exercising the SparseArray class
#include "SparseArray.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  SparseArray strings(50);  // Create a sparse array with capacity for 50

  // Exercise subscripting
  try {
    strings[10] = "Many";
    strings[15] = "hands";
    strings[21] = "make";
    strings[32] = "light";
    strings[44] = "work";
    strings[1] = strings[10]+" "+ strings[15];
    strings[2] = strings[21]+" "+ strings[32];
    strings[5] = strings[1] + " " + strings[2] + " " + strings[44];
    strings.show();
    strings[14] = strings[60];
  }
  catch(exception& e) {
    cout << endl << "Exception caught: " << e.what();
  }

  // Exercise the copy constructor and assignment operator
  try {
    SparseArray copies(strings);
    copies.show();
    copies[0] = strings[5];
    strings = copies;
    strings.show();
  }
  catch(exception& e) {
    cout << endl << "Exception caught: " << e.what();
  }

  cout << endl;
  return 0;
}