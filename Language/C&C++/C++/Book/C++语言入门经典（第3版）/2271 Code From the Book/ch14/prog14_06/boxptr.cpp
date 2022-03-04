// BoxPtr.cpp
#include <iostream>
#include "List.h"
#include "BoxPtr.h"
using std::cout;
using std::endl;

BoxPtr::BoxPtr(TruckLoad& load):rLoad(load) {
  pBox = rLoad.getFirstBox();
}

Box& BoxPtr::operator*() const {
  if(pBox)
    return *pBox;
  else   {
    cout << endl << "Dereferencing null BoxPtr";
    exit(1);
  }
}

Box* BoxPtr::operator->() const {
  return pBox;
}

Box* BoxPtr::operator++() {
  return pBox = rLoad.getNextBox();
}

const Box* BoxPtr::operator++(int) {
  Box* pTemp = pBox;
  pBox = rLoad.getNextBox();
  return pTemp;
}

BoxPtr::operator bool() {
  return pBox != 0;
}
