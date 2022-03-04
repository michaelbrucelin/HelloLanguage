// Exercise 13.2 Comparing Sequence objects File:  main.cpp
// The tricky part is the parameter to the equals() member of the class
// If you don't declare it as a reference, the default coopy constructor
// will be called with dire consequences...
#include <iostream>
#include "Sequence.h"
using std::cout;
using std::endl;

int main() {

  const int nSeq = 5;
 Sequence** pSequences = new Sequence*[nSeq];
 pSequences[0] = new Sequence(5,6);
 pSequences[1] = new Sequence(5,5);
 pSequences[2] = new Sequence(5,6);
 pSequences[3] = new Sequence(5,5);
 pSequences[4] = new Sequence(4,8);

 for(int i = 0 ; i<nSeq ; i++) {
   cout << endl << "sequence[" << i << "]:";
   pSequences[i]->show();
 }

 for(int i = 0 ; i<4 ; i++)
   for(int j = i+1 ; j<5 ; j++) 
     cout << endl 
          << "sequence[" << i << "] "
          << ((pSequences[i]->equals(*pSequences[j])) ? "is" : "is not")
          << " equal to "
          << "sequence[" << j << "].";

// First delete the Sequence objects in the free store
 for(int i = 0 ; i<nSeq ; i++)
   delete pSequences[i];

 delete[] pSequences;      // Now delete the array holding their addresses 
  return 0;
}