// Exercise 16.2 Lengths.h
// Length classes 

#ifndef LENGTHS_H
#define LENGTHS_H
#include <cmath>

class BaseLength {
  public:
    BaseLength():mm(0){}                                   // Default constructor
    BaseLength(long n):mm(n){}                             // Constructor from millimeters
    virtual double length();                               // Return the length

  protected:
    long mm;
    static double mmPerInch;
    static double mmPerMeter;
    static double inchesPerYard;
    static double yardsPerPerch;
};

// Classes representing specific units
// Lengths are always stored in the base class member mm which
// can result in an error of up to 1 mm in the length displayed.
// This is because the conversion of the length to integer rounds down
// and there can be further small errors from decimal/binary floating point conversions. 
class Inches: public BaseLength {
  public:
    Inches():BaseLength(){}
    Inches(double ins):BaseLength(static_cast<long>(0.5+mmPerInch*ins)){}
    double length();                                                 // Return the length
 };

class Meters: public BaseLength {
  public:
    Meters():BaseLength(){}
    Meters(double m):BaseLength(static_cast<long>(0.5+mmPerMeter*m)){}
    double length();                                                // Return the length
};

class Yards: public BaseLength {
  public:
    Yards():BaseLength(){}
    Yards(double yds):BaseLength(static_cast<long>(0.5+inchesPerYard*mmPerInch*yds)){}
    double length();                                                  // Return the length
};

class Perches: public BaseLength {
  public:
    Perches():BaseLength(){}
    Perches(double pch):BaseLength(static_cast<long>(0.5+yardsPerPerch*inchesPerYard*mmPerInch*pch)){}
    double length();                                                  // Return the length
};
#endif