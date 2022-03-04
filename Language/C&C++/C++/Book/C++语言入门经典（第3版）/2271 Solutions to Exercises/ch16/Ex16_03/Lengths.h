// Exercise 16.3 Lengths.h
// Length classes 

#ifndef LENGTHS_H
#define LENGTHS_H
#include <string>
using std::string;

// Class name declarations - we need these because we want to refer
// to the class names before they are defined.
class Inches;
class Yards;
class Meters;
class Perches;

class BaseLength {
  public:
    BaseLength():mm(0){}                                    // Default constructor
    BaseLength(long n):mm(n){}                              // Constructor from millimeters
    virtual double length() const;                          // Return the length

    // These conversion operators will be inherited in all
    // derived classes. If you wanted to re-implement them in a class -
    // perhaps because you sotred the length in class units in a derived class member -
    // you would declare them as virtual here.
    operator Inches()const;                                    // Conversion to Inches
    operator Yards()const;                                     // Conversion to Yards
    operator Meters()const;                                    // Conversion to Meters
    operator Perches()const;                                   // Conversion to Perches

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
    double length() const;                                           // Return the length
 };

class Meters: public BaseLength {
  public:
    Meters():BaseLength(){}
    Meters(double m):BaseLength(static_cast<long>(0.5+mmPerMeter*m)){}
    double length() const;                                           // Return the length
};

class Yards: public BaseLength {
  public:
    Yards():BaseLength(){}
    Yards(double yds):BaseLength(static_cast<long>(0.5+inchesPerYard*mmPerInch*yds)){}
    double length() const;                                           // Return the length
};

class Perches: public BaseLength {
  public:
    Perches():BaseLength(){}
    Perches(double pch):
              BaseLength(static_cast<long>(0.5+yardsPerPerch*inchesPerYard*mmPerInch*pch)){}
    double length() const;                                           // Return the length
};
#endif