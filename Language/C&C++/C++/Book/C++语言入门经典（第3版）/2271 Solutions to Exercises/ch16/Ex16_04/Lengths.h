// Exercise 16.4 Lengths.h
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
    BaseLength():mm(0){}                            // Default constructor
    BaseLength(long n):mm(n){}                      // Constructor from millimeters
    virtual double length() const;                  // Return the length
    virtual operator Inches()const;                 // Conversion to Inches
    virtual operator Yards()const;                  // Conversion to Yards
    virtual operator Meters()const;                 // Conversion to Meters
    virtual operator Perches()const;                // Conversion to Perches

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
    Inches(Yards& yds);
    Inches(Meters& m);
    Inches(Perches& p);
    double length() const;                          // Return the length
 };

class Meters: public BaseLength {
  public:
    Meters():BaseLength(){}
    Meters(double m):BaseLength(static_cast<long>(0.5+mmPerMeter*m)){}
    Meters(Yards& yds);
    Meters(Inches& ins);
    Meters(Perches& p);
    double length()const;                           // Return the length
};

class Yards: public BaseLength {
  public:
    Yards():BaseLength(){}
    Yards(double yds):BaseLength(static_cast<long>(0.5+inchesPerYard*mmPerInch*yds)){}
    Yards(Perches& p);
    Yards(Inches& ins);
    Yards(Meters& m);
    double length() const;                          // Return the length
};

class Perches: public BaseLength {
  public:
    Perches():BaseLength(){}
    Perches(double pch):BaseLength(static_cast<long>(0.5+yardsPerPerch*inchesPerYard*mmPerInch*pch)){}
    Perches(Inches& ins);
    Perches(Yards& yds);
    Perches(Meters& m);
    double length() const;                          // Return the length
};
#endif