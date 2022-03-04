// Exercise 15.3 - Animal.h
// Animal class and classes derived from Animal

#ifndef ANIMAL_H
#define ANIMAL_H
#include <string>
using std::string;

class Animal {
  public:
    Animal(string theName, int wt);   // Constructor
    void who() const;                 // Display name and weight

  private:
    string name;                      // Name of the animal
    int weight;                       // Weight of the animal
};

class Lion: public Animal {
  public:
    Lion(string theName, int wt):Animal(theName, wt){}
    void who() const;      // Public member to access protected base function
};

class Aardvark: public Animal {
  public:
    Aardvark(string theName, int wt):Animal(theName, wt){}
    void who() const;      // Public member to access protected base function
};

#endif