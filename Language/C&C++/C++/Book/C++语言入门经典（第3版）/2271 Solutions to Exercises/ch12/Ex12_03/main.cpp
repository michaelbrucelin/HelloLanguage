// Exercise 12.3 Implementing add(), subtract() and multiply() - main.cpp
/***********************************************************
 By returning the this pointer in the functions we can call
 the functions successively in a single statement. Note the
 parameter is a const reference - const because the argument
 is not changed by the function and a reference to avoid
 the overhead of copying objects.
 The only other requirement for achieving the calculation
 in a single statement is figuring out how to sequence to
 operations to allow this.
 ***********************************************************/
#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

int main() {
  Integer a(4);
  Integer b(6);
  Integer c(7);
  Integer d(8);
  Integer x(5);
  // We can calculate 4*5*5*5+6*5*5+7*5+8 as:
  //     ((4*5+6)*5+7)*5+8
  Integer result(a);   // Set result object as copy of a
  Integer* pResult = &result;
  cout << "Result is " 
       << pResult->multiply(x)->add(b)->multiply(x)->add(c)->multiply(x)->add(d)->getValue()
       <<  endl;
  return 0;
}