// Program 14.6 Using a smart pointer    File: prog14_06.cpp
#include <iostream>
#include <cstdlib>               // For random number generator
#include <ctime>                 // For time function
using std::cout;
using std::endl;

#include "Box.h"
#include "List.h"
#include "BoxPtr.h"

// Function to generate random integers from 1 to count
inline int random(int count) {
  return 1+static_cast<int>((count*static_cast<long>(std::rand()))/(RAND_MAX+1L));
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
  BoxPtr pLoadBox(load);                      // Create smart pointer
  
  Box maxBox = *pLoadBox;                     // Intialize maxBox object using * operator
  if(pLoadBox)                                // Try the bool conversion
    cout << endl << "Volume of first Box is " << pLoadBox->volume();  // ...and ->

  while(++pLoadBox)                           // Prefix increment smart pointer
    if(maxBox < *pLoadBox)
      maxBox = *pLoadBox;

  cout << endl
       << "The largest box in the list is "
       << maxBox.getLength()  << " by "
       << maxBox.getWidth() << " by "
       << maxBox.getHeight()  << " with volume " 
       << maxBox.volume()     << endl;
return 0;
}
