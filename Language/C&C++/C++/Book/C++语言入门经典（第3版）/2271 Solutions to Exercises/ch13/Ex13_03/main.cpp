// Exercise 13.3 Comparing Sequence objects File:  main.cpp
/****************************************************************************
 We must delete the equals() function from the class definition and
 remove its definition from the Sequence.cpp file.
 We will add the declaration for a friend function, equals() to the class
 and add its definition to this file that contains main().
 Implementing equals() as a member of the Sequencse class is by far the better
 solution because the friend function underminesthe security of the class.
 You should only use friend functions when it's absolutely necessary.

******************************************************************************/
#include <iostream>
#include "Sequence.h"
using std::cout;
using std::endl;

bool equals(const Sequence& s1, const Sequence& s2) {
  if(s1.length != s2.length)
    return false;
  for(int i = 0 ; i<s1.length ; i++)
    if(s1.pSequence[i] != s2.pSequence[i])
      return false;
  return true;
}
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
          << (equals(*pSequences[i], *pSequences[j]) ? "is" : "is not")
          << " equal to "
          << "sequence[" << j << "].";

// First delete the Sequence objects in the free store
 for(int i = 0 ; i<nSeq ; i++)
   delete pSequences[i];

 delete[] pSequences;      // Now delete the array holding their addresses 
  return 0;
}