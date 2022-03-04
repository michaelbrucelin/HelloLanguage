// Program 13.1 Exercising a linked list of Box objects    File: prog13_01.cpp
#include <iostream>
#include <cstdlib>               // For random number generator
#include <ctime>                 // For time function

using std::cout;
using std::endl;

#include "Box.h"
#include "List.h"

// Function to generate a random integer 1 to count
inline int random(int count) {
return 1+ static_cast<int>
             (count*static_cast<double>(std::rand())/(RAND_MAX+1.0));
}

int main() {
  const int dimLimit = 100;           // Upper limit on Box dimensions
  std::srand((unsigned)std::time(0)); // Initialize the random number generator

  // Create an empty list
  TruckLoad load1;

  // Add 10 random sized Box objects to the list
  for(int i = 0 ; i < 10 ; i++)
    load1.addBox(new Box(random(dimLimit), random(dimLimit), random(dimLimit)));

  // Find the largest Box in the list
  Box* pBox = load1.getFirstBox();
  Box* pNextBox;
  while(pNextBox = load1.getNextBox())  // Assign & then test pointer to next Box
    if(pBox->compareVolume(*pNextBox) < 0)
      pBox = pNextBox;

  cout << endl
       << "The largest box in the first list is "
       << pBox->getLength() << " by "
       << pBox->getWidth() << " by "
       << pBox->getHeight() << endl;

  const int boxCount = 20;               // Number of elements in Box array
  Box boxes[boxCount];                   // Array of Box objects

  for(int i = 0 ; i < boxCount ; i++) 
    boxes[i] = Box(random(dimLimit), random(dimLimit), random(dimLimit));

  TruckLoad load2(boxes, boxCount);

  // Find the largest Box in the list
  pBox = load2.getFirstBox();
  while(pNextBox = load2.getNextBox())
    if(pBox->compareVolume(*pNextBox) < 0)
      pBox = pNextBox;

  cout << endl
       << "The largest box in the second list is "
       << pBox->getLength() << " by "
       << pBox->getWidth() << " by "
       << pBox->getHeight() << endl;

  // Delete the Box objects in the first list
  pNextBox = load1.getFirstBox();
  while(pNextBox) {
    delete pNextBox; 
    pNextBox = load1.getNextBox();
  }
  return 0;
}
