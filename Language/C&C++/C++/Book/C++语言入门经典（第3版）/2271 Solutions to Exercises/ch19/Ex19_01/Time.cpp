// Exercise 19.1 Time.cpp
//Time class implementation  File

#include "Time.h"
#include <iomanip>
#include <iostream>

// Constructor
Time::Time(int h, int m, int s) {
  seconds = s%60;            // Seconds left after removing minutes
  minutes = m+s/60;          // Minutes plus minutes from seconds
  hours = h+minutes/60;      // Hours plus hours from minutes
  minutes %= 60;             // Minutes left after removing hours
}

// Insertion operator
std::ostream& operator <<(std::ostream& out, const Time& rT) {
  out << ' ' << rT.getHours() << ':';
  char fillCh = out.fill('0');       // Set fill for leading zeros

  out << std::setw(2) << rT.getMinutes() << ':' 
      << std::setw(2) << rT.getSeconds() << ' '; 
  out.fill(fillCh);                  // Restore old fill character
  return out;
}