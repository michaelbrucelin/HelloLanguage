// Program 14.4 Adding Box objects  File: prog14_04.cpp
#include <iostream>
#include <cstdlib>               // For random number generator
#include <ctime>                 // For time function
using std::cout;
using std::endl;

#include "Box.h"

// Function to generate random integers from 1 to count
inline int random(int count) {
  return 
      1+static_cast<int>(count* static_cast<double>(std::rand())/(RAND_MAX + 1.0));
}

// Display box dimensions
void show(const Box& aBox) {
  cout << endl
       << aBox.getLength() << " by " << aBox.getWidth() << " by " << aBox.getHeight();
}

int main() {
  const int dimLimit = 100;           // Upper limit on Box dimensions
  std::srand((unsigned)std::time(0)); // Initialize the random number generator

  const int boxCount = 20;            // Number of elements in Box array
  Box boxes[boxCount];                // Array of Box objects
  
  // Create 20 Box objects
  for(int i = 0 ; i < boxCount ; i++)
    boxes[i] = Box(random(dimLimit), random(dimLimit), random(dimLimit));

  int first = 0;                      // Index of first Box object of pair
  int second = 1;                     // Index of second Box object of pair
  double minVolume = (boxes[first] + boxes[second]).volume();

  for(int i = 0 ; i < boxCount - 1 ; i++)
    for(int j = i + 1 ; j < boxCount ; j++)
      if(boxes[i] + boxes[j] < minVolume)       {
        first = i;
        second = j;
        minVolume = (boxes[i] + boxes[j]).volume();
      }

  cout << "The objects that sum to the smallest volume are:";
  cout << endl << "boxes[" << first << "] ";
  show(boxes[first]);
  cout << endl << "boxes[" << second << "] ";
  show(boxes[second]);
  cout << endl << "Volume of the sum is " << minVolume << endl;

  return 0;
}
