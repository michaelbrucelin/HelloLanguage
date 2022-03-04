// Exercise 16.1 Animals.h 
// Animal classes and class defining a Zoo
#ifndef ANIMALS_H
#define ANIMALS_H
#include <string>
using std::string;

class Animal {
  public:
    Animal(string theName, int wt);       // Constructor
    virtual string who() const;           // Return string containing name and weight
    virtual string sound() = 0;           // Display sound of an animal

  private:
    string name;                          // Name of the animal
    int weight;                           // Weight of the animal
};

class Sheep: public Animal {
  public:
    Sheep(string theName, int wt):Animal(theName, wt){}
    string who() const;                   // Return string containing name and weight
    string sound();                       // Display sound of a sheep
};

class Dog: public Animal {
  public:
    Dog(string theName, int wt):Animal(theName, wt){}
    string who() const;                   // Return string containing name and weight
    string sound();                       // Display sound of a dog
};

class Cow: public Animal {
  public:
    Cow(string theName, int wt):Animal(theName, wt){}
    string who() const;                   // Return string containing name and weight
    string sound();                       // Return sound of a cow
};

// The Zoo class shows how you can use an enumeration 
// to get a constant as part of a class definition.
// This is used to specify the dimension of the array member.
class Zoo {
  public:
    Zoo():number(0){}                     // Default constructor for an empty zoo
    Zoo(Animal** pNewAnimals, int count); // Constructor from an array of animals
    bool addAnimal(Animal* pAnimal);      // Add an animal to the zoo
    void showAnimals();                   // Output the animals and the sound they make

  private:
    enum{maxAnimals = 50};                // Defines maximum number of animals
    Animal* pAnimals[maxAnimals];         // Stores addresses of the animals
    int number;                           // Number of animals in the Zoo
};

#endif