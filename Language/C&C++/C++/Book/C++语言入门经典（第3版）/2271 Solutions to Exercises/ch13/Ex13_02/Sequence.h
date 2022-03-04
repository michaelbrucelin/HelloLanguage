// Exercise 13.2 Sequence.h
// Class encapsulating a sequence of integers
// We add a declaration for the equals() function member here

#ifndef SEQUENCE_H
#define SEQUENCE_H

class Sequence {
public:
  Sequence();                            // Default constructor
  Sequence(int start, int length = 2);   // Constructor
  ~Sequence();                           // Destructor
  void show();                           // Output a sequence
  bool equals(const Sequence& sequence) const; // Compare this sequence with another

private:
  int* pSequence;                        // Pointer to a sequence
  int length;                            // Sequence length
};
#endif