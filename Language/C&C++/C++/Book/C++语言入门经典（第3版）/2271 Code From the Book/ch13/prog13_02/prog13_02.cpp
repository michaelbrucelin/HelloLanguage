// Program 13.2 Exercising the copy constructor    File: prog13_02.cpp
#include <iostream>
#include <cstdlib>               // For random number generator
#include <ctime>                 // For time function

using std::cout;
using std::endl;

#include "Box.h"
#include "List.h"

// Function to generate a random integer 1 to count
inline int random(int count) {
  return 1 + static_cast<int>(count*static_cast<double>(rand())/(RAND_MAX+1.0));
}

// Find the Box in the list with the largest volume
Box* maxBox(TruckLoad& Load) {
  Box* pBox = Load.getFirstBox();
  Box* pNextBox;
  while(pNextBox = Load.getNextBox())  // Assign & then test pointer to next Box 
    if(pBox->compareVolume(*pNextBox) < 0)
      pBox = pNextBox;
  return pBox;
}

int main() {
  const int dimLimit = 100;              // Upper limit on Box dimensions
  std::srand((unsigned)std::time(0));    // Initialize the random number generator

  // Create a list
  TruckLoad load1;

  // Add 3 Boxes to the list
  for(int i = 0 ; i < 3 ; i++)
    load1.addBox(new Box(random(dimLimit), random(dimLimit), random(dimLimit)));

  Box* pBox = maxBox(load1);         // Find the largest Box in the first list

  cout << endl
       << "The largest box in the first list is "
       << pBox->getLength()  << " by "
       << pBox->getWidth() << " by "
       << pBox->getHeight()  << endl;

  TruckLoad load2(load1);            // Create a copy of the first list

  pBox = maxBox(load2);              // Find the largest Box in the second list

  cout << endl                       // Display it
       << "The largest box in the second list is "
       << pBox->getLength()  << " by "
       << pBox->getWidth() << " by "
       << pBox->getHeight()  << endl;

  // Add 5 more boxes to the second list
  for(int i = 0; i<5; i++) 
    load2.addBox(new Box(random(dimLimit), random(dimLimit), random(dimLimit)));

  pBox = maxBox(load2);             // Find the largest Box in the extended list

  cout << endl                      // Display it
       << "The largest box in the extended second list is "
       << pBox->getLength()  << " by "
       << pBox->getWidth() << " by "
       << pBox->getHeight()  << endl;
  
  // Count the number of boxes in the first list and display the count
  Box* pNextBox = load1.getFirstBox();
  int count = 0;                         // Box count
  while(pNextBox) {                      // While there is a box
    count++;                             // Increment the count
    pNextBox = load1.getNextBox();       // and get the next box
  }
  cout << endl << "First list still contains " 
       << count << " Box objects."<< endl;
  
  // Delete the Box objects in the free store
  pNextBox = load2.getFirstBox();
  while(pNextBox) {
    delete pNextBox;
    pNextBox = load2.getNextBox();
  }
  return 0;
}
