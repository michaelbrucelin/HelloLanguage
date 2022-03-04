// TruckLoad.h definition of the TruckLoad class
#ifndef TRUCKLOAD_H
#define TRUCKLOAD_H
#include <list>
#include "Box.h"


class TruckLoad {
  typedef std::list<Box> Contents;                    // Private type definition

  public:
    typedef Contents::const_iterator const_iterator;  // Public type definition
    TruckLoad() {}
    TruckLoad(const Box& one_box) : load (1, one_box) {}

    template<typename FwdIter> 
    TruckLoad(FwdIter first, FwdIter last) : load(first, last) {}

    void add_box(const Box& new_box) { load.push_back(new_box); }


    const_iterator begin() const { return load.begin(); }
    const_iterator end() const { return load.end(); }

  private:
    Contents load;
};
#endif
