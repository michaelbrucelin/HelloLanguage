// Array class template definition
#ifndef ARRAY_H
#define ARRAY_H
#include <stdexcept>                       // For the exception classes

template <typename T> class Array {
  private:
    T* elements;                           // Array of type T
    size_t size;                           // Number of elements in the array

  public:
    explicit Array(size_t arraySize);      // Constructor
    Array(const Array& theArray);          // Copy Constructor
    ~Array();                              // Destructor
    T& operator[](size_t index);             // Subscript operator
    const T& operator[](size_t index) const; // Subscript operator
    Array& operator=(const Array& rhs);              // Assignment operator
};

// Constructor
template <typename T>                      // This is a template with parameter T
Array<T>::Array(size_t arraySize) : size(arraySize) {
  elements = new T[size];
}

// Copy Constructor
template <typename T>
Array<T>::Array(const Array& theArray) {
  size = theArray.size;
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
T& Array<T>::operator[](size_t index) {
  if(index < 0 || index >= size)
    throw std::out_of_range(index < 0 ? "Negative index" : "Index too large");

  return elements[index];
}

// Subscript operator for const objects
template <typename T>
const T& Array<T>::operator[](size_t index) const {
  if(index < 0 || index >= size)
    throw std::out_of_range(index < 0 ? "Negative index" : "Index too large");

  return elements[index];
}

// Assignment operator
template <typename T>
Array<T>& Array<T>::operator=(const Array& rhs) {
  if(&rhs == this)                            // If lhs == rhs
    return *this;                             //  just return lhs

  if(elements)                                // If lhs array exists
    delete[]elements;                         // then release the free store memory

  size = rhs.size;
  elements = new T[rhs.size];
  for(int i = 0 ; i < size ; i++)
    elements[i] = rhs.elements[i];
}

#endif
