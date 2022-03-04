// Exercise 11.4 Outputting a SharedData array - main.cpp
// The shareddata.h and shareddata.cpp file are as for Ex 11.3
#include "shareddata.h"
#include <iostream>
using std::cout;
using std::endl;

void show_array(SharedData* array, int length);  // Display a SharedData array

int main() {
  int number = 99;
  long lNumber = 9999999L;
  double value = 1.7320508;
  float pi = 3.142f;
  SharedData shared[8];  // Array of SharedData elements

  // Assign values arbitrarily to elments
  shared[0].pdData = &value;
  shared[0].type = pDouble;
  shared[1].piData = &number;      
  shared[1].type = pInt;
  shared[2].iData = number;      
  shared[2].type = Int;
  shared[3].lData = lNumber;      
  shared[3].type = Long;
  shared[4].plData = &lNumber;      
  shared[4].type = pLong;
  shared[5].dData = value;      
  shared[5].type = Double;
  shared[6].fData = pi;      
  shared[6].type = Float;
  shared[7].pfData = &pi;      
  shared[7].type = pFloat;

  show_array(shared, sizeof shared/sizeof shared[0]);

  return 0;
}

// Display an array of SharedData elements
void show_array(SharedData* array, int length) {

  for(int i = 0 ; i<length ; i++){
    cout << endl << "[" << i << "] ";

    switch(array[i].type) {
      case Double:
      cout << "Double = " << array[i].dData;
      break;
      case Float:
      cout << "Float = " << array[i].fData;
      break;
      case Long:
      cout << "Long = " << array[i].lData;
      break;
      case Int:
      cout << "Int = " << array[i].iData;
      break;
      case pDouble:
      cout << "double* = " << *array[i].pdData;
      break;
      case pFloat:
      cout << "float* = " << *array[i].pfData;
      break;
      case pLong:
      cout << "long* = " << *array[i].plData;
      break;
      case pInt:
      cout << "int* = " << *array[i].piData;
      break;
      default:
      cout << endl << "Error - Invalid Type" << endl;
      break;
    }
  }
  cout << endl;
}