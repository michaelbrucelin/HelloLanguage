// Array class template definition
#ifndef ARRAY_H
#define ARRAY_H
#include <stdexcept>                       // For the exception classes

template <typename T, long startIndex> class Array {
  private:
    T* elements;                           // Array of type T
    size_t size;                           // Number of elements in the array

  public:
    explicit Array(size_t arraySize);      // Constructor
    Array(const Array& theArray);          // Copy Constructor
    ~Array();                              // Destructor
    T& operator[](long index);             // Subscript operator
    const T& operator[](long index) const; // Subscript operator
    Array& operator=(const Array& rhs);    // Assignment operator
};

// Constructor
template <typename T, long startIndex> 
Array<T, startIndex>::Array(size_t arraySize) : size(arraySize) {
  elements = new T[size];
}

// Copy Constructor
template <typename T, long startIndex>
Array<T, startIndex>::Array(const Array& theArray) {
  size = theArray.size;
  elements = new T[size];
  for(int i = 0 ; i < size ; i++)
    elements[i] = theArray.elements[i];
}

// Destructor
template <typename T, long startIndex>
Array<T, startIndex>::~Array() {
  delete[] elements;
}

// Subscript operator
template <typename T, long startIndex>
T& Array<T, startIndex>::operator[](long index) {
  if(index < startIndex || index > startIndex + static_cast<long>(size)-1)
    throw std::out_of_range(index < startIndex ? "Index too small" : "Index too large");

  return elements[index-startIndex];
}

// Subscript operator for const objects
template <typename T, long startIndex>
const T& Array<T, startIndex>::operator[](long index) const {
  if(index < startIndex || index > startIndex + static_cast<long>(size)-1)
    throw std::out_of_range(index < startIndex ? "Index too small" : "Index too large");

  return elements[index-startIndex];
}

// Assignment operator
template <typename T, long startIndex>
Array<T, startIndex>& Array<T, startIndex>::operator=(const Array& rhs) {
  if(&rhs == this)                            // If lhs == rhs
    return *this;                             //  just return lhsa

  if(elements)                                // If lhs array exists
    delete[]elements;                         // then release the free store memory

  size = rhs.size;
  elements = new T[rhs.size];
  for(int i = 0 ; i < size ; i++)
    elements[i] = rhs.elements[i];
}

#endif
