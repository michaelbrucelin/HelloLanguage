// List.h classes supporting a linked list
#ifndef LIST_H
#define LIST_H

#include "Box.h"

class TruckLoad {
  public:
    ~TruckLoad();                              // TruckLoad destructor
    TruckLoad(Box* pBox = 0, int count = 1);   // Constructor
    TruckLoad(const TruckLoad& load);          // Copy constructor

    Box* getFirstBox();                        // Retrieve the first Box
    Box* getNextBox();                         // Retrieve the next Box
    void addBox(Box* pBox);                    // Add a new Box to the list

  private:
    // Class defining a list element
    class Package {
      public:
        ~Package();                                // Destructor
        Box* pBox;                                 // Pointer to the Box
        Package* pNext;                            // Pointer to the next Package

        void setNext(Package* pPackage);           // Add package to end of list
        Package(Box* pNewBox);                     // Constructor  
    };
 
    Package* pHead;                            // First in the list
    Package* pTail;                            // Last in the list
    Package* pCurrent;                         // Last retrieved from the list
};
#endif
