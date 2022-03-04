// Program 11.5 Working with a person.     File: person.cpp
#include <iostream>
#include "person.h"
  // Display the name
  void Name::show() {
    std::cout << firstname << " " << surname << std::endl;
  }

  // Display the date
  void Date::show() {
    std::cout << month << "/" << day << "/" << year << std::endl;
  }

  // Display a phone number
  void Phone::show() {
    std::cout << areacode << " " << number << std::endl;
  }

  // Display a person
  void Person::show() {
    std::cout << std::endl;
    name.show();
    std::cout << "Born: ";
    birthdate.show();
    std::cout << "Telephone: ";
    number.show(); 
  }

  // Calculate the age up to a given date
  int Person::age(Date& date) {
    if(date.year <= birthdate.year)
      return 0;

    int years = date.year - birthdate.year;
    if((date.month>birthdate.month) || 
                  (date.month == birthdate.month && date.day>= birthdate.day))
    return years;
      else
    return --years;
  }
