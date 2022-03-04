// Exercise 15_4 Person.cpp 
// Person class implementation

#include "Person.h"
#include <iostream>
using namespace std;

Person::Person(int theAge, string theName, char theGender): age(theAge), 
                                                   name(theName), gender(theGender) {
  // Instead of just initializing the members with the argument values, you could
  // validate the arguments by doing reasonableness checks. 
  // e.g. Age should be positive and less than 130 say. gender should be 'm' or 'f'
  // To handle a failure sensibly we really need exceptions, but we don't get to those 
  // until chapter 17. 
}

// Display details of Person object
void Person::who() const {
  cout << "\nThis is " << name << " who is " << age << " years old.";
}

// Display details of Employee object
void Employee::who() const {
  cout << endl 
       << name << " is a " << (gender=='f'? "female": "male") 
       << " employee aged " << age << "."; 
}

// Display details of Executive object
void Executive::who() const {
  cout << endl 
       << name << " is a " << (gender=='f'? "female": "male") << " executive."; 
}