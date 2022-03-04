// List.cpp Implementations for the Package and TruckLoad classes
#include <iostream>
#include "Box.h"
#include "List.h"
using std::cout;
using std::endl;

// Package class functions
// Package constructor
TruckLoad::Package::Package(Box* pNewBox):pBox(pNewBox), pNext(0){}  

// TruckLoad class functions
// Constructor
TruckLoad::TruckLoad(Box* pBox, int count) {
  pHead = pTail = pCurrent = 0;

  if(count > 0 && pBox != 0)
  for(int i = 0 ; i<count ; i++)
    addBox(pBox+i);
  return;
}

// Copy constructor
TruckLoad::TruckLoad(const TruckLoad& Load) {
  pHead = pTail = pCurrent = 0;
  if(Load.pHead == 0)
    return;

  Package* pTemp = Load.pHead;                 // Saves addresses for new chain
  do {
    addBox(pTemp->pBox);
  }while(pTemp = pTemp->pNext);
}

// Destructor
TruckLoad::~TruckLoad() {
  while(pCurrent = pHead->pNext) {
    delete pHead;                     // Delete the previous
    pHead = pCurrent;                 // Store address of next
  }
    delete pHead;                     // Delete the last
}

// Get the first Box in the list
Box* TruckLoad::getFirstBox() {
  pCurrent = pHead;
  return pCurrent->pBox;
}

// Get the next Box in the list
Box* TruckLoad::getNextBox() {
  if(pCurrent)
    pCurrent = pCurrent->pNext;     // pCurrent is not null so set to next
  else                              // pCurrent is null 
    pCurrent = pHead;               //  so set to the first list element

  return pCurrent ? pCurrent->pBox : 0;
}

// Add a list element
void TruckLoad::addBox(Box* pBox) {
  Package* pPackage = new Package(pBox);           // Create a Package

  if(pHead)                                        // Check list is not empty
    pTail->pNext = pPackage;                       // Add the new object to the tail
  else                                             // List is empty
    pHead = pPackage;                              // so new object is the head
  pTail = pPackage;                                // Store its address as tail
}

// Subscript operator
Box TruckLoad::operator[](int index) const {
  if(index<0) {                               // Check for negative index
    cout << endl << "Negative index";
    exit(1);
  }

  Package* pPackage = pHead;                  // Address of first Package
  int count = 0;                              // Package count
  do {
    if(index == count++)                      // Up to index yet?
      return *pPackage->pBox;                 // If so return the Box
  } while(pPackage = pPackage->pNext);

  cout << endl << "Out of range index";       // If we get to here index is too high
  exit(1);
}
