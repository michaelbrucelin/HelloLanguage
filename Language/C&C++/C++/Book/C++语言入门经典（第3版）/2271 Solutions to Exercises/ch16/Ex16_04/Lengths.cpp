// Exercise 16.4 Lengths.cpp
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

// Constructors for conversions
Inches::Inches(Yards& yds):BaseLength(yds.BaseLength::length()){}
Inches::Inches(Meters& m):BaseLength(m.BaseLength::length()){}
Inches::Inches(Perches& p):BaseLength(p.BaseLength::length()){}

// Virtual function to return the length
double Yards::length() const {
  return mm/(inchesPerYard*mmPerInch); 
}

// Constructors for conversions
Yards::Yards(Perches& p):BaseLength(p.BaseLength::length()){}
Yards::Yards(Inches& ins):BaseLength(ins.BaseLength::length()){}
Yards::Yards(Meters& m):BaseLength(m.BaseLength::length()){}

// Virtual function to return the length
double Meters::length() const {
  return mm/mmPerMeter; 
}

// Constructors for conversions
Meters::Meters(Yards& yds):BaseLength(yds.BaseLength::length()){}
Meters::Meters(Inches& ins):BaseLength(ins.BaseLength::length()){}
Meters::Meters(Perches& p):BaseLength(p.BaseLength::length()){}

// Virtual function to return the length
double Perches::length() const {
  return mm/(yardsPerPerch*inchesPerYard*mmPerInch); 
}

// Constructors for conversions
Perches::Perches(Inches& ins):BaseLength(ins.BaseLength::length()){}
Perches::Perches(Yards& yds):BaseLength(yds.BaseLength::length()){}
Perches::Perches(Meters& m):BaseLength(m.BaseLength::length()){}

// Virtual base function to return the length
double BaseLength::length() const {
  return static_cast<double>(mm);
}

// Base function to convert length to Inches
BaseLength::operator Inches() const {
  return Inches(mm/mmPerInch); 
}

// Base function to convert length to Yards
BaseLength::operator Yards() const {
  return Yards(mm/(inchesPerYard*mmPerInch)); 
}

// Base function to convert length to Meters
BaseLength::operator Meters() const {
  return Meters(mm/mmPerMeter); 
}

// Base function to convert length to Perches
BaseLength::operator Perches() const {
  return Perches(mm/(yardsPerPerch*inchesPerYard*mmPerInch)); 
}