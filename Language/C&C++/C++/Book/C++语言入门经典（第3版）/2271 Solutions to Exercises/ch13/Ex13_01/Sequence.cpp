// Exercise 13.1 Sequence.cpp
// Implementation of the Sequence class
// encapsulating an arbitrary length sequence of integers
#include "Sequence.h"
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

// Default constructor
Sequence::Sequence() {
  length = 10;
  pSequence = new int[length];
  for(int i = 0 ; i<length ; i++)
    pSequence[i] = i;
}

// Constructor
Sequence::Sequence(int start, int length) {
  this->length = length<2 ? 2 : length;
  pSequence = new int[length];
  for(int i = 0 ; i<length ; i++)
    pSequence[i] = start+i;
}

// Destructor
Sequence::~Sequence(){
//  cout << endl << " destructor called.";    // Uncomment to trace destructor calls
  delete[] pSequence;
}

// Output a sequence
void Sequence::show() {
  for(int i = 0 ; i<length ; i++) {
    if(i%10 == 0)
      cout << endl;
    cout << std::setw(2+(pSequence[0]+length)/10) << pSequence[i];
  }
  cout << endl;
}