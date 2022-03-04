// Exercise 12.1 Implementing an Integer class - main.cpp 
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
 
  cout << endl << "Create j with the value 5000." << endl;
  Integer j(5000);
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
  return 0;
}