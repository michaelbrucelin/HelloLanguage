// List.h classes supporting a linked list
#ifndef LIST_H
#define LIST_H

#include "Box.h"

// Class defining a TruckLoad - implements the list
class TruckLoad {
  public:
    TruckLoad(Box* pBox = 0, int count = 1);   // Constructor
    TruckLoad(const TruckLoad& load);          // Copy constructor
    ~TruckLoad();                              // TruckLoad destructor

    Box* getFirstBox();                        // Retrieve the first Box
    Box* getNextBox();                         // Retrieve the next Box
    void addBox(Box& rBox);                    // Add a new Box to the list

  private:
    // Class defining a list element
    class Package {
          public:
            Box& rBox;                                 // Reference to the Box
            Package* pNext;                            // Pointer to the next Package

            ~Package();                                // Destructor

            void setNext(Package* pPackage);           // Add package to end of list
            Package(Box& rNewBox);                     // Constructor  
    };
 
  	Package* pHead;                            // First in the list
    Package* pTail;                            // Last in the list
    Package* pCurrent;                         // Last retrieved from the list
};
#endif






