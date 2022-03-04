// Exercise 17.4 SparseArray.cpp
// Implementation of the SparseArray class

#include "SparseArray.h"
#include <stdexcept>
#include <string>
#include <iostream>
#include <iomanip>
using std::string;
using std::cout;
using std::endl;

// Helper function to convert an integer to a C-style string
char* itoa(int n, char* str) {
  int temp = n;
  if(n<0)
    n = -n;
  int len = 0;
  // Create characters in string in reverse order
  do {
    str[len++] = n%10 + '0';
    n/=10;
  }while(n != 0);

  if(temp<0)           // If n was negative
    str[len++] = '-';  // Add a minus sign
  str[len] = '\0';     // Append null

  // Now reverse the string in place
  char ch = 0;
  for(int i = 0,  j = len-1 ; i<j ; i++, j--) {
    ch = str[i];
    str[i] = str[j];
    str[j] = ch;
  }
  return str;
}

// Copy constructor
SparseArray::SparseArray(const SparseArray& array) {
  maxElements = array.maxElements;                // Copy max element count

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
  }
  else
    pLast = pFirst = 0;
}

  
// Destructor
SparseArray::~SparseArray() {
  Node* pCurrent = pFirst;
  Node* pTemp = 0;
  while(pCurrent) {                                // If there is a node
    pTemp = pCurrent->pNext;                       // Save the address of the next
    delete pCurrent;                               // Delete the current
    pCurrent = pTemp;                              // Make the next current
  }
}

// Assignment operator
SparseArray& SparseArray::operator=(const SparseArray& array) {
   if(this == &array)             // Check for rhs same as lhs
    return *this;

  maxElements = array.maxElements;
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
  }
  else
    pLast = pFirst = 0;
  return *this;
}

// Subscript operator for non-const objects
string& SparseArray::operator[](int index) {
  if(index<0 || index>=maxElements) {      // Check for out of range index
    string message = "Invalid index in SparseArray: ";
    char pValue[10];                      // Stores string representation of index
    message += string(itoa(index, pValue));
    message += string(". Index limits are 0 to ")+string(itoa(maxElements-1, pValue, 10));
    
    throw std::out_of_range(message.c_str());
  }

  // Search the list for a node corresponding to index
  Node* pCurrent = pFirst;
  while(pCurrent) {
    if(pCurrent->index == index)
      return *pCurrent->pStr;
    if(pCurrent->index > index)
      break;
    pCurrent = pCurrent->pNext;
  }

  // If we get to here, the element doesn't exist
  // so we must create one
  Node* pNode = new Node(index);
  pNode->pStr = new string;
  if(pCurrent) {                         // If its not the end of the list we must insert the element
    if(pCurrent->pPrevious) {            // If current has a previous node just insert the new node   
      pCurrent->pPrevious->pNext = pNode;
      pNode->pPrevious = pCurrent->pPrevious;
      pCurrent->pPrevious = pNode;
      pNode->pNext = pCurrent;
    }
    else {                               // Current must be the first so add new node as first
      pNode->pNext = pCurrent;
      pCurrent->pPrevious = pNode;
      pFirst = pNode;
    }
  }
  else {                         // We must append the element
    if(pLast) {
      pLast->pNext = pNode;
      pNode->pPrevious = pLast;
      pLast = pNode;
    }
    else 
      pFirst = pLast = pNode;
  }
  return *pNode->pStr;      // Return the new element
}

// Display the elements of a SparseArray
void SparseArray::show() {
  Node* pCurrent = pFirst;
  while(pCurrent) {
    cout << "\n[" << std::setw(2) << pCurrent->index << "] = " << *pCurrent->pStr;
    pCurrent = pCurrent->pNext;
  }
}