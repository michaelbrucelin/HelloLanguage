// Box.h
#ifndef BOX_H
#define BOX_H
#include <iostream>

class Box {
  public:
    Box(double lv = 1, double wv = 1, double hv = 1);   // Constructor

    
    virtual ~Box();                  // Virtual Destructor
    void showVolume() const;         // Show the volume of an object
    virtual double volume() const;   // Calculate the volume of a Box object

    // Friend insertion operator
    friend std::ostream& operator<<(std::ostream& out, const Box& rBox);

  protected:
    double length;
    double width;
    double height;
};
#endif
