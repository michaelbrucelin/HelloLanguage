// Program 14.5 Using the overloaded subscript operator  File: prog14_05.cpp
#include <iostream>
#include <cstdlib>               // For random number generator
#include <ctime>                 // For time function
using std::cout;
using std::endl;

#include "Box.h"
#include "List.h"

// Function to generate random integers from 1 to count
inline int random(int count) {
  return 1+static_cast<int>((count*static_cast<long>(std::rand()))/(RAND_MAX+1L));
}

// Display box dimensions
void show(const Box& aBox) {
  cout << endl
       << aBox.getLength() << " by " << aBox.getWidth() 
                           << " by " << aBox.getHeight();
}

int main() {
  const int dimLimit = 100;      // Upper limit on Box dimensions
  std::srand((unsigned)std::time(0)); // Initialize the random number generator

  const int boxCount = 20;       // Number of elements in Box array
  Box boxes[boxCount];           // Array of Box objects
  
  // Create 20 Box objects
  for(int i = 0 ; i < boxCount ; i++)
    boxes[i] = Box(random(dimLimit), random(dimLimit), random(dimLimit));

  TruckLoad load = TruckLoad(boxes, boxCount);

  // Find the largest Box in the list
  Box maxBox = load[0];

  for(int i = 1 ; i < boxCount ; i++)
    if(maxBox < load[i])
      maxBox = load[i];

  cout << endl
       << "The largest box in the list is ";
  show(maxBox);
  cout << endl;
  return 0;
}
