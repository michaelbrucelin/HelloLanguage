// Exercise 16.3 Lengths.cpp
// Length classes implementations

#include "Lengths.h"

// Static data members of BaseLength
double BaseLength::mmPerInch = 25.4;
double BaseLength::inchesPerYard = 36.0;
double BaseLength::mmPerMeter = 1000.0;
double BaseLength::yardsPerPerch = 5.5;

// Virtual function to return the length
double Inches::length() const {
  return mm/mmPerInch; 
}

// Virtual function to return the length
double Yards::length() const {
  return mm/(inchesPerYard*mmPerInch); 
}

// Virtual function to return the length
double Meters::length() const {
  return mm/mmPerMeter; 
}

// Virtual function to return the length
double Perches::length() const {
  return mm/(yardsPerPerch*inchesPerYard*mmPerInch); 
}

// Virtual base function to return the length
double BaseLength::length() const {
  return static_cast<double>(mm);
}


// Function to convert length to Inches
BaseLength::operator Inches() const {
  return Inches(mm/mmPerInch); 
}

// Function to convert length to Yards
BaseLength::operator Yards() const {
  return Yards(mm/(inchesPerYard*mmPerInch)); 
}

// Function to convert length to Meters
BaseLength::operator Meters() const {
  return Meters(mm/mmPerMeter); 
}

// Function to convert length to Perches
BaseLength::operator Perches() const {
  return Perches(mm/(yardsPerPerch*inchesPerYard*mmPerInch)); 
}