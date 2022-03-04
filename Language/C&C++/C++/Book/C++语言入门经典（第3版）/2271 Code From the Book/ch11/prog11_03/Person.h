// Person.h Definitions for Person and related structures
#ifndef PERSON_H
#define PERSON_H

// Structure representing a name
struct Name {
  char firstname[80];
  char surname[80];
  
  void show();        // Display the name
};

// Structure representing a date
struct Date {
  int day;
  int month;
  int year;

  void show();         // Display the date
};

// Structure representing a phone number
struct Phone {
  int areacode;
  int number;

  void show();          // Display a phone number
};

// Structure representing a person
struct Person {
  Name name;
  Date birthdate;
  Phone number;

   void show();          // Display a person
  int age(Date& date);   // Calculate the age up to a given date
};
#endif
