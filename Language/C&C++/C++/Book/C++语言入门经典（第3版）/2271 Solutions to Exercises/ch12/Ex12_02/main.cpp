// Exercise 12.2 Using a function with a reference parameter in the Integer class - main.cpp
/***********************************************************
 Using the version of compare()with the pass-by-value parameter,
 the copy constructor is called because a copy of the argument
 is passed to the function.
 Using the version with the reference parameter a reference
 to the object is passed to the function so no constructor call
 is necessary.
 You cannot overload a function with a reference parameter with
 a function that has a non-reference parameter because the
 compiler cannot tell which function should be called in any 
 particular instance.
 ***********************************************************/
#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

int main() {
  cout << endl << "Create i with the value 10." << endl;
  Integer i(10);
  i.show();
  cout << "Change value  of i to 15." << endl;
  i.setValue(15);
  i.show();
 
  cout << endl << "Create j from object i." << endl;
  Integer j(i);
  j.show();
  cout << "Set value of j to 150 times that of i." << endl;
  j.setValue(150*i.getValue());
  j.show();

  cout << endl << "Create k with the value 789." << endl;
  Integer k(789);
  k.show();
  cout << "Set value of k to sum of i and j values." << endl;
  k.setValue(i.getValue()+j.getValue());
  k.show();

  cout << endl << "Result of comparing i and j is " <<  i.compare(j) << endl;
  cout << endl << "Result of comparing k and j is " <<  k.compare(j) << endl;

  return 0;
}