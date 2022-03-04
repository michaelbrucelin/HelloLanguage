// Exercise 16.1 Exercising Zoo and Animal classes
#include "Animals.h"
#include <cstdlib>
#include <ctime>
#include <iostream>
using  std::cout;
using  std::endl;

// Function to generate a random integer 0 to count-1
int random(int count) {
  return static_cast<int>((count*static_cast<long>(rand()))/(RAND_MAX+1L));
}

int main() {
  std::srand((unsigned)std::time(0));       // Seed random number generator

  char* dogNames[] = { "Fido", "Rover"   , "Lassie" , "Lambikins",   "Poochy",
                       "Spit", "Gnasher" , "Samuel" , "Wellington" , "Patch"   };
  char* sheepNames[] = { "Bozo"   , "Killer", "Tasty", "Woolly", "Chops",
                         "Blackie", "Whitey", "Eric" , "Sean"  , "Shep"   };
  char* cowNames[] = { "Dolly", "Daisy"  , "Shakey", "Amy"  , "Dilly",
                       "Dizzy", "Eleanor", "Zippy" , "Zappy", "Happy" };
  int minDogWt = 1;               // Minimum weight of a dog in pounds
  int maxDogWt = 120;             // Maximum weight of a dog in pounds
  int minSheepWt = 80;            // Minimum weight of a dog in pounds
  int maxSheepWt = 150;           // Maximum weight of a dog in pounds
  int minCowWt = 800;             // Minimum weight of a dog in pounds
  int maxCowWt = 1500;            // Maximum weight of a dog in pounds

  Animal* pAnimals[20];           // Array to store pointers to animals
  int numAnimals = sizeof pAnimals/sizeof(Animal*);
  // Create random animals
  for(int i = 0 ; i<numAnimals ; i++)
    switch(random(3)) {
    case 0:                // Create a sheep
      pAnimals[i] = new Sheep(sheepNames[random(sizeof sheepNames/sizeof(char*))],
                              minSheepWt+random(maxSheepWt-minSheepWt+1));
      break;
    case 1:                // Create a dog
      pAnimals[i] = new Dog(dogNames[random(sizeof dogNames/sizeof(char*))],
                              minDogWt+random(maxDogWt-minDogWt+1));
      break;
    case 2:                // Create a cow
      pAnimals[i] = new Cow(cowNames[random(sizeof cowNames/sizeof(char*))],
                              minCowWt+random(maxCowWt-minCowWt+1));
      break;
    default:
      cout << "\nInvalid animal type selection.";
      break;
  }

  // Create a zoo containing the animals
  // You could also create an empty zoo and add animals one at a time
  Zoo theZoo(pAnimals, numAnimals);  
  theZoo.showAnimals();    // Display the animals

  // Release memory for the animals
  // Note that the array was not created dynamically
  // so we must not try to delete the array - just the individual elements
  for(int i = 0; i<numAnimals ; i++)
    delete pAnimals[i];

  cout << endl;

  return 0;
}