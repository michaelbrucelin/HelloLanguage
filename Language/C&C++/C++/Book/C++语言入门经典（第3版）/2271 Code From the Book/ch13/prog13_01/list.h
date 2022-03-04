// List.h classes supporting a linked list
#ifndef LIST_H
#define LIST_H

#include "Box.h"

// Class defining a list element
class Package {
  public:
    Package(Box* pNewBox);                        // Constructor
    Box* getBox() const;                          // Retrieve the Box pointer
    Package* getNext() const;                     // Get next package address
    void setNext(Package* pPackage);              // Add package to end of list

  private:
    Box* pBox;                                    // Pointer to the Box
    Package* pNext;                               // Pointer to the next Package
};


// Class defining a TruckLoad - implements the list
class TruckLoad {
  public:
    TruckLoad(Box* pBox = 0, int count = 1);   // Constructor

    Box* getFirstBox();                        // Retrieve the first Box
    Box* getNextBox();                         // Retrieve the next Box
    void addBox(Box* pBox);                    // Add a new Box to the list

  private:
    Package* pHead;                            // First in the list
    Package* pTail;                            // Last in the list
    Package* pCurrent;                         // Last retrieved from the list
};
#endif
