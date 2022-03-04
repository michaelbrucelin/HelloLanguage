// Array class template definition
#ifndef ARRAY_H
#define ARRAY_H
#include <stdexcept>                       // For the exception classes

template <typename T> class Array {
  private:
    T* elements;                           // Array of type T
    size_t size;                           // Number of elements in the array
    long start;                            // Starting index value
  public:
    explicit Array(size_t arraySize, long startIndex = 0); // Constructor
    Array(const Array& theArray);          // Copy Constructor
    ~Array();                              // Destructor
    T& operator[](long index);             // Subscript operator
    const T& operator[](long index) const; // Subscript operator
    Array& operator=(const Array& rhs);    // Assignment operator
};

// Constructor
template <typename T> 
Array<T>::Array(size_t arraySize, long startIndex) : size(arraySize), start(startIndex) {
  elements = new T[size];
}

// Copy Constructor
template <typename T>
Array<T>::Array(const Array& theArray) {
  size = theArray.size;
  start = theArray.start;
  elements = new T[size];
  for(int i = 0 ; i < size ; i++)
    elements[i] = theArray.elements[i];
}

// Destructor
template <typename T>
Array<T>::~Array() {
  delete[] elements;
}

// Subscript operator
template <typename T>
T& Array<T>::operator[](long index) {
  if(index < start || index > start + static_cast<long>(size)-1)
    throw std::out_of_range(index < start ? "Index too small" : "Index too large");

  return elements[index-start];
}

// Subscript operator for const objects
template <typename T>
const T& Array<T>::operator[](long index) const {
  if(index < start || index > start + static_cast<long>(size)-1)
    throw std::out_of_range(index < startIndex ? "Index too small" : "Index too large");

  return elements[index-start];
}

// Assignment operator
template <typename T>
Array<T>& Array<T>::operator=(const Array& rhs) {
  if(&rhs == this)                            // If lhs == rhs
    return *this;                             //  just return lhsa

  if(elements)                                // If lhs array exists
    delete[]elements;                         // then release the free store memory

  size = rhs.size;
  start = rhs.start;
  elements = new T[rhs.size];
  for(int i = 0 ; i < size ; i++)
    elements[i] = rhs.elements[i];
}

#endif
