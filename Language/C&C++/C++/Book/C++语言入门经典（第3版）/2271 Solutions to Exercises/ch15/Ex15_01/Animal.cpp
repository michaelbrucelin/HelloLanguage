// Exercise 15.1 - Animal.cpp
// Implementations of the Animal class and classes derived from Animal

#include "Animal.h"
#include <string>
#include <iostream>
using std::cout;
using std::string;

// Constructor
Animal::Animal(string theName, int wt): name(theName), weight(wt) {}

// Identify the animal
void Animal::who() const {
  cout << "\nMy name is " << name << " and I weigh " << weight << "lbs.";
}