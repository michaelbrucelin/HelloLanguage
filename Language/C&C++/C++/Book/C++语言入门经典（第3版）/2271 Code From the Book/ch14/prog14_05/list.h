// List.h classes supporting a linked list
#ifndef LIST_H
#define LIST_H

#include "Box.h"

class TruckLoad {
  public:
    // Constructors
    TruckLoad(Box* pBox = 0, int count = 1);         // Constructor
    TruckLoad::TruckLoad(const TruckLoad& Load);     // Copy constructor

    ~TruckLoad();                                    // Destructor
    
    Box* getFirstBox();                              // Retrieve the first Box
    Box* getNextBox();                               // Retrieve the next Box
    void addBox(Box* pBox);                          // Add a new Box to the list
    Box operator[](int index) const;              // Overloaded subscript operator

  private:
   class Package {
      public:
        Box* pBox;                                   // Pointer to the Box
        Package* pNext;                              // Pointer to the next Package

        Package(Box* pNewBox);                       // Constructor
};

    Package* pHead;                                  // First in the list
    Package* pTail;                                  // Last in the list
    Package* pCurrent;                               // Last retrieved from the list
};

#endif
