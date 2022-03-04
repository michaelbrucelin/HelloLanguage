// List.cpp

#include "Box.h"
#include "List.h"
#include <iostream>
using std::cout;
using std::endl;

// Package class definitions
// Package constructor
TruckLoad::Package::Package(Box& rNewBox):rBox(rNewBox), pNext(0){}

// Package destructor
TruckLoad::Package::~Package() { 
  cout << "Package destructor called." << endl; 
}

// Add package to end of list
void TruckLoad::Package::setNext(Package* pPackage) { pNext = pPackage; }



// TruckLoad class member definitions
// TruckLoad constructor
TruckLoad::TruckLoad(Box* pBox, int count) {
  pHead = pTail = pCurrent = 0;

  if((count > 0) && (pBox != 0))
    for(int i = 0 ; i<count ; i++)
      addBox(*(pBox+i));
}

// TruckLoad copy constructor
TruckLoad::TruckLoad(const TruckLoad& load) {
  pHead = pTail = pCurrent = 0;
  if(load.pHead == 0)
    return;

  Package* pTemp = load.pHead;           // Saves addresses for new chain
  do {
    addBox(pTemp->rBox);
  }while(pTemp = pTemp->pNext);          // Assign and then test pointer to next Box

}

// TruckLoad destructor
TruckLoad::~TruckLoad() {
  cout << "TruckLoad destructor called." << endl;
  while(pCurrent = pHead->pNext) {
    delete pHead;                     // Delete the previous
    pHead = pCurrent;                 // Store address of next
  }
    delete pHead;                     // Delete the last
}


// Retrieve the first Box
Box* TruckLoad::getFirstBox() {
  pCurrent = pHead;
  return &pCurrent->rBox;
}

// Retrieve the next Box
Box* TruckLoad::getNextBox() {
  if(pCurrent)
    pCurrent = pCurrent->pNext;            // pCurrent is not null so set to next
  else                                     // pCurrent is null 
    pCurrent = pHead;                      //  so set to the first list element

  return pCurrent ? &pCurrent->rBox : 0;
}

// Add a new Box to the list
void TruckLoad::addBox(Box& rBox) {
  Package* pPackage = new Package(rBox);   // Create a Package

  if(pHead)                                // Check list is not empty
    pTail->pNext = pPackage;               // Add the new object to the tail
  else                                     // List is empty
    pHead = pPackage;                      // so new object is the head
  pTail = pPackage;                        // Store its address as tail
}
