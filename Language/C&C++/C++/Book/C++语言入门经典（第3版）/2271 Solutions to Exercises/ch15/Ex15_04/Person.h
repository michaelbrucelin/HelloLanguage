// Exercise 15.4 Person.h
// Person class and classes derived from Person

#ifndef PERSON_H
#define PERSON_H
#include <string>
using std::string;

class Person {
  public:
    Person():age(0), name(""), gender('f'){}            // Default constructor
    Person(int theAge, string theName, char theGender);
    void who() const;                                   // Display details

  protected:
    int age;                                            // Age in years
    string name;
    char gender;                                        // 'm' or 'f'
};

class Employee: public Person {
  public:
    Employee(){}                 // Default constructor - necessary to declare arrays
    Employee(int theAge, string theName, char theGender, long persNum):
        Person(theAge, theName, theGender), personnelNumber(persNum){}
    void who() const;    // Display details

  protected:
    long personnelNumber;

};

class Executive: public Employee {
  public:
    Executive(){}               // Default constructor - necessary to declare arrays
    Executive(int theAge, string theName, char theGender, long persNum):
        Employee(theAge, theName, theGender, persNum){}
    void who() const;           // Display details
};

#endif