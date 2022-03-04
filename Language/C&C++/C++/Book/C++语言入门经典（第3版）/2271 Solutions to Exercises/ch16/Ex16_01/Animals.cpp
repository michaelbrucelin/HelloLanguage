// Exercise 16.1 Animals.cpp
// Implementations of the Animal class and classes derived from Animal

#include "Animals.h"
#include <string>
#include <cstdlib>
#include <iostream>
using std::string;
using std::cout;
using std::endl;

// Constructor
Animal::Animal(string theName, int wt): name(theName), weight(wt) {}

// Return string decribing the animal
string Animal::who() const {
  char wtStr[10];
  return string("My name is ")+name + string(". My weight is ")+
            string(itoa(weight, wtStr,10))+string(" lbs.");
}

// Return string decribing the sheep
string Sheep::who() const {
  return string("I am a sheep. ")+Animal::who();   // Call base function for common data
}

// Make like a sheep
string Sheep::sound() {
  return string("Baaaa!!");
}

// Return string decribing the dog
string Dog::who() const {
  return string("I am a dog. ")+Animal::who();     // Call base function for common data
}

// Make like a dog
string Dog::sound() {
  return string("Woof woof!!");
}

// Return string decribing the cow
string Cow::who() const {
  return string("I am a cow. ")+Animal::who();     // Call base function for common data
}

// Make like a cow
string Cow::sound() {
  return string("Mooooo!!");
}

// Constructor from an array of animals
Zoo::Zoo(Animal** pNewAnimals, int count) {
  if(count>maxAnimals) {
    cout << "\nMaximum animals allowed is " << maxAnimals
         << ". Only that number stored.";
    count = maxAnimals;
  }
  for(int i = 0; i<count ; i++)
    pAnimals[i] = pNewAnimals[i];
  number = count;
}

// Add an animal to the zoo
// Returns true if the animal is added successfully.
bool Zoo::addAnimal(Animal* pAnimal) {
  if(number == maxAnimals)   {
    cout << "\nThe zoo is full. Animal not stored.";
    return false;
  }
  pAnimals[number++] = pAnimal;
  return true;
}

// Output the animals and the sound they make
void Zoo::showAnimals() {
  for(int i = 0; i<number ; i++)
    cout << endl << pAnimals[i]->who() << ' ' << pAnimals[i]->sound();
}