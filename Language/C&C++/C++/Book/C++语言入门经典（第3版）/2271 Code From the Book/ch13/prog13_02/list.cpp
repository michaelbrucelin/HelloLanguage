// List.cpp
#include "Box.h"
#include "List.h"

// Package class definitions
// Package constructor
TruckLoad::Package::Package(Box* pNewBox):pBox(pNewBox), pNext(0){}   

// Add package to end of list
void TruckLoad::Package::setNext(Package* pPackage) { pNext = pPackage; }


// TruckLoad class member definitions
// TruckLoad constructor
TruckLoad::TruckLoad(Box* pBox, int count) {
  pHead = pTail = pCurrent = 0;

  if((count > 0) && (pBox != 0))
    for(int i = 0 ; i<count ; i++)
      addBox(pBox+i);
}

// TruckLoad copy constructor
TruckLoad::TruckLoad(const TruckLoad& load) {
  pHead = pTail = pCurrent = 0;
  if(load.pHead == 0)
    return;

  Package* pTemp = load.pHead;      // Saves addresses for new chain
  do   {
    addBox(pTemp->pBox);
  }while(pTemp = pTemp->pNext);     // Assign and then test pointer to next Box

}

// Retrieve the first Box
Box* TruckLoad::getFirstBox() {
  pCurrent = pHead;
  return pCurrent->pBox;
}

// Retrieve the next Box
Box* TruckLoad::getNextBox() {
  if(pCurrent)
    pCurrent = pCurrent->pNext;    // pCurrent is not null so set to next
  else                             // pCurrent is null 
    pCurrent = pHead;              //  so set to the first list element

  return pCurrent ? pCurrent->pBox : 0;
}

// Add a new Box to the list
void TruckLoad::addBox(Box* pBox) {
  Package* pPackage = new Package(pBox);   // Create a Package

  if(pHead)                                // Check list is not empty
    pTail->pNext = pPackage;               // Add the new object to the tail
  else                                     // List is empty
    pHead = pPackage;                      // so new object is the head
  pTail = pPackage;                        // Store its address as tail
}
