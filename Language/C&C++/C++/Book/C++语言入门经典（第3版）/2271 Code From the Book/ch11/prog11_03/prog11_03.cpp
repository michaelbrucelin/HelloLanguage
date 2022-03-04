// Program 11.3 Working with a Person    File: prog11_03.cpp
#include <iostream>
#include "person.h"
using std::cout;
using std::endl;

int main() {
  Person her = {
                 { "Letitia", "Gruntfuttock" },     // Initializes Name member
                 {1, 4, 1965                 },     // Initializes Date member
                 {212, 5551234               }      // Initializes Phone member
               };

  Person actress;
  actress = her;                                   // Copy members of her
  her.show();
  Date today = { 15, 6, 2003 };

  cout << endl << "Today is ";
  today.show();
  cout <<  endl; 

  cout << "Today " << actress.name.firstname << " is " 
       << actress.age(today) << " years old."
       << endl;
  return 0;
}
