// Exercise 18.3 SparseArrayT.h
// SparseArray class template definition

#ifndef SPARSEARRAYT_H
#define SPARSEARRAYT_H
#include <cstdlib>
#include <stdexcept>
#include <string>
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;
using std::string;


template<typename T> class SparseArray {
  public:
    SparseArray(): pFirst(0), pLast(0){}                       // Constructor
    SparseArray(const SparseArray& array);                     // Copy constructor
    ~SparseArray();                                            // Destructor
    SparseArray& operator=(const SparseArray& array);          // Assignment operator
    T& operator[](int index);                                  // Subscript SparseArray
    void show();                                               // display array elements

  private:
    // Node class definition
    class Node {
      public:
        int index;                       // Index of element
        T* pObject;                      // Address of object
        Node* pNext;                     // Pointer to next node
        Node* pPrevious;                 // Pointer to previous node

        Node(int newIndex): 
                 index(newIndex), pObject(new T), pNext(0), pPrevious(0){} // Constructor
        Node(const Node& node): 
                 index(node.index), pObject(new T(*node.pObject)), pNext(0), pPrevious(0){}
                                                               // Copy constructor
        ~Node(){ delete pObject; }                             // Destructor
    };

    Node* pFirst;                        // Pointer to first element node
    Node* pLast;                         // Pointer to last element node
    // maxElements member not used now
};


// Copy constructor template
template<typename T> SparseArray<T>::SparseArray(const SparseArray& array) {
  if(array.pFirst) {                              // If there is a first element
    pLast = pFirst = new Node(*array.pFirst);     // Duplicate it

    Node* pTemp = 0;
    Node* pCurrent = array.pFirst;
    while(pCurrent = pCurrent->pNext) {            // Duplicate any further nodes
      pTemp = pLast;                               // Save the address of the last
      pLast = new Node(*pCurrent);                 // Make the new one the last
      pTemp->pNext = pLast;                        // Set the next pointer of old last
      pLast->pPrevious = pTemp;                    // Set previous pointer of new last                      
    }
  } else
    pLast = pFirst = 0;
}

// Destructor template
template<typename T> SparseArray<T>::~SparseArray() {
  Node* pCurrent = pFirst;
  Node* pTemp = 0;
  while(pCurrent) {                                  // If there is a node
    pTemp = pCurrent->pNext;                       // Save the address of the next
    delete pCurrent;                               // Delete the current
    pCurrent = pTemp;                              // Make the next current
  }
}

// Assignment operator template
template<typename T> SparseArray<T>& SparseArray<T>::operator=(const SparseArray& array) {
   if(this == &array)                              // Check for rhs same as lhs
    return *this;

  Node* pCurrent = 0;
  if(array.pFirst) {
    pLast = pFirst = new Node(*array.pFirst);
    Node* pTemp = 0;
    pCurrent = array.pFirst;
    while(pCurrent = pCurrent->pNext) {
      pTemp = pLast;
      pLast = new Node(*pCurrent);
      pTemp->pNext = pLast;
      pLast->pPrevious = pTemp;
      pTemp = pLast;
    }
  } else
    pLast = pFirst = 0;
  return *this;
}

// Subscript operator for non-const objects
template<typename T> T& SparseArray<T>::operator[](int index) {
  if(index<0) {       // Check for out of range inde
    string message = "Invalid index in SparseArray: ";
    char pValue[10];                      // Stores string representation of index
    message += string(itoa(index, pValue, 10));

    throw std::out_of_range(message.c_str());
  }

  // Search the list for a node corresponding to index
  Node* pCurrent = pFirst;
  while(pCurrent) {
    if(pCurrent->index == index)
      return *pCurrent->pObject;
    if(pCurrent->index > index)
      break;
    pCurrent = pCurrent->pNext;
  }

  // If we get to here, the element doesn't exist
  // so we must create one
  Node* pNode = new Node(index);
  pNode->pObject = new T;
  if(pCurrent) {                         // If its not the end of the list we must insert the element
    if(pCurrent->pPrevious) {            // If current has a previous node just insert the new node   
      pCurrent->pPrevious->pNext = pNode;
      pNode->pPrevious = pCurrent->pPrevious;
      pCurrent->pPrevious = pNode;
      pNode->pNext = pCurrent;
    } else {                             // Current must be the first so add new node as first
      pNode->pNext = pCurrent;
      pCurrent->pPrevious = pNode;
      pFirst = pNode;
    }
  } else {                         // We must append the element
    if(pLast) {
      pLast->pNext = pNode;
      pNode->pPrevious = pLast;
      pLast = pNode;
    } else 
      pFirst = pLast = pNode;
  }
  return *pNode->pObject;      // Return the new element
}

// Display the elements of a SparseArray
template<typename T> void SparseArray<T>::show() {
  Node* pCurrent = pFirst;
  while(pCurrent) {
    cout << "\n[" << std::setw(2) << pCurrent->index << "] = " << *pCurrent->pObject;
    pCurrent = pCurrent->pNext;
  }
}
#endif //SPARSEARRAY_H