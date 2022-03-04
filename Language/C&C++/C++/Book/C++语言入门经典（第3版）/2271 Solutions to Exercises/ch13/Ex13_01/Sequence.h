// Exercise 13.1 Sequence.h
#ifndef SEQUENCE_H
#define SEQUENCE_H

// Class encapsulating a sequence of integers
class Sequence {
public:
  Sequence();                            // Default constructor
  Sequence(int start, int length = 2);   // Constructor
  ~Sequence();                           // Destructor
  void show();                           // Output a sequence
private:
  int* pSequence;                        // Pointer to a sequence
  int length;                            // Sequence length
};
#endif