// Exercise 13.1 Implementing the Sequence class File:  main.cpp
#include <iostream>
#include <cstdlib>
#include <ctime>

#include "Sequence.h"
using std::cout;
using std::endl;

// Function to generate a random integer from start to end
inline int random(int start, int end) {
  return start + static_cast<int>((end*static_cast<long>(std::rand()))/(RAND_MAX+1L));
}

int main() {
 std::srand((unsigned)std::time(0));    // Initialize the random number generator

 const int nSeq = 5;
 Sequence** pSequences = new Sequence*[nSeq];
 for(int i = 0 ; i<nSeq ; i++){
   // Generate a sequence with a random start and length
   pSequences[i] = new Sequence(random(1,50), random(2,10));
   cout << endl << "Sequence " << i+1 << ":";
   pSequences[i]->show();          // Output the sequence
 }

 // Now the default sequence
 Sequence sequence;
 cout << endl << "Default sequence :";
 sequence.show();                 // Output the default sequence        

 // First delete the Sequence objects in the free store
 for(int i = 0 ; i<nSeq ; i++)
   delete pSequences[i];

 delete[] pSequences;      // Now delete the array holding their addresses 

  return 0;
}