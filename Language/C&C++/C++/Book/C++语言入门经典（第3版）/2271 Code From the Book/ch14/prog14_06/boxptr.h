#ifndef BOXPTR_H
#define BOXPTR_H
#include "List.h"

class BoxPtr {
  public:
    BoxPtr(TruckLoad& load);                 // Constructor
    Box& operator*() const;                  // * overload
    Box* operator->() const;                 // -> overload
    Box* operator++();                       // Prefix increment
    const Box* operator++(int);              // Postfix increment
    operator bool();                         // Conversion to bool

  private:
    Box* pBox;                               // Points to current Box in rLoad
    TruckLoad& rLoad;

    // Not accessible so not implemented
    BoxPtr();                                // Default constructor
    BoxPtr(BoxPtr&);                         // Copy constructor
    BoxPtr& operator=(const BoxPtr&);        // Assignment operator
};
#endif
