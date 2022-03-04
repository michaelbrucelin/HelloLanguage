// Exercise 12.4 Using a friend function - main.cpp 
/***********************************************************
 Implementing compare()as a friend is quite simple. We must
 declare the function as a friend in the class definition.
 We now need both objects as arguments and the code in the
 body of the function just compares the n members of the arguments.
 Both parameters are const references.
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

  cout << endl << "Result of comparing i and j is " <<  compare(i, j) << endl;
  cout << endl << "Result of comparing k and j is " <<  compare(k, j) << endl;

  return 0;
}

int compare(const Integer& obj1, const Integer& obj2) {
  if(obj1.n < obj2.n)
    return -1;
  else if(obj1.n==obj2.n)
    return 0;
  return 1;
}