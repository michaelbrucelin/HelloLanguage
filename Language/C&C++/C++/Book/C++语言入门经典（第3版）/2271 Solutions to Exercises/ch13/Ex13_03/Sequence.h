// Exercise 13.3 Sequence.h
// Class encapsulating a sequence of integers

#ifndef SEQUENCE_H
#define SEQUENCE_H

class Sequence {
public:
  Sequence();                            // Default constructor
  Sequence(int start, int length = 2);   // Constructor
  ~Sequence();                           // Destructor
  void show();                           // Output a sequence
  friend bool equals(const Sequence& s1, const Sequence& s2); // Friend for comparing Sequence objects
private:
  int* pSequence;                        // Pointer to a sequence
  int length;                            // Sequence length
};
#endif