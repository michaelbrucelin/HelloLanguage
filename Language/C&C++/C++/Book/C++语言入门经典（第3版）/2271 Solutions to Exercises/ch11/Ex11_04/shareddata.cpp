// Exercise 11.4 Exercising SharedData - shareddata.cpp
// SharedData function definition
#include "shareddata.h"
#include <iostream>
using std::cout;
using std::endl;

void SharedData::show() {
  switch(type) {
    case Double:
    cout << endl << "Double value is " << dData << endl;
    break;
    case Float:
    cout << endl << "Float value is " << fData << endl;
    break;
    case Long:
    cout << endl << "Long value is " << lData << endl;
    break;
    case Int:
    cout << endl << "Int value is " << iData << endl;
    break;
    case pDouble:
    cout << endl << "Pointer to double value is " << *pdData << endl;
    break;
    case pFloat:
    cout << endl << "Pointer to float value is " << *pfData << endl;
    break;
    case pLong:
    cout << endl << "Pointer to long value is " << *plData << endl;
    break;
    case pInt:
    cout << endl << "Pointer to int value is " << *piData << endl;
    break;
    default:
    cout << endl << "Error - Invalid Type" << endl;
    break;
  }
}