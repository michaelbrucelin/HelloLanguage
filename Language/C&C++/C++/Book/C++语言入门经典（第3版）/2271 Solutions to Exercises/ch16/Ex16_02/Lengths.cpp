// Exercise 16.2 Lengths.cpp
// Length classes implementations

#include "Lengths.h"

// Static data members of BaseLength
double BaseLength::mmPerInch = 25.4;
double BaseLength::inchesPerYard = 36.0;
double BaseLength::mmPerMeter = 1000.0;
double BaseLength::yardsPerPerch = 5.5;

// Virtual base function to return the length
double BaseLength::length() {
  return static_cast<double>(mm);
}

// Virtual function to return the length
double Inches::length() {
  return mm/mmPerInch; 
}

// Virtual function to return the length
double Yards::length() {
  return mm/(inchesPerYard*mmPerInch); 
}

// Virtual function to return the length
double Meters::length() {
  return mm/mmPerMeter; 
}

// Virtual function to return the length
double Perches::length() {
  return mm/(yardsPerPerch*inchesPerYard*mmPerInch); 
}