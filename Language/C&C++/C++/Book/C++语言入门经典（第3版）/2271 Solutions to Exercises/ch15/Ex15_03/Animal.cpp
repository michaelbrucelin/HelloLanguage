// Exercise 15.3 - Animal.cpp
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

// Identify the Lion
void Lion::who() const {
  cout << "\nI am a lion.";
  Animal::who();      // Call base function
}

// Identify the Aardvark
void Aardvark::who() const {
  cout << "\nI am an aardvark.";
  Animal::who();      // Call base function
}