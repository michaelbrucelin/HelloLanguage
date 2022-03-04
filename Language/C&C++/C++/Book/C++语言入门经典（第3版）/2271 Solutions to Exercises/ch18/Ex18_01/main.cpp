// Exercise 18.1 Exercising the SparseArray class template
// We create a sparse aray of integers, populate 20 of its 
// entries (checking for duplicates among the randomly generated indices)
// and output the resulting index/value pairs.

#include "SparseArrayT.h"
#include <cstdlib>
#include <ctime>
#include <string>
#include <iostream>
using std::cout;
using std::endl;
using std::string;


// Function to generate a random integer 0 to count-1
int random(int count) {
  return static_cast<int>((count*static_cast<long>(rand()))/(RAND_MAX+1L));
}

int main() {
  SparseArray<int> numbers;               // Create sparse array
  const int count = 20;                   // Number of elements to be created
  int indexes[count];                     // Records index values used
  int index = 0;                          // Stores new index value
  srand((unsigned)time(0));               // Seed random number generator

  try {
    for(int i = 0 ; i<count ; i++) {       // Create count entries in numbers array
      // Must ensure that indexes after the first are not duplicates
      for(;;) {
        index = random(500);                // Get a random index 0 to 499
        for(int j = 0; j<i-1 ; j++)         // Compare with previous indexes
          if(index == indexes[j]) {         // If new index equals previous
            index = -1;                     // Set new index negative
            break;
          }
       if(index>=0)                        // Index still non-negative?
          break;                            // then we have a unique index
      }
      numbers[index] = 32+random(181);      // Store value at new index position
    }
  }
  catch(std::exception& e) {
    cout << "\nException thrown " << e.what();
  }
  numbers.show();

  cout << endl;
  return 0;
}