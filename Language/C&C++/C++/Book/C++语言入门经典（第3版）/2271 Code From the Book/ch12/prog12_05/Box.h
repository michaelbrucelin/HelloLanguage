// Box.h Definition of the Box class
#ifndef BOX_H
#define BOX_H

class Box {
  public:
    // Constructor
    Box(double lengthValue = 1.0, double widthValue = 1.0,
                                                     double heightValue = 1.0);

    // Function to calculate the volume of a box
    double volume();

    // Inline functions to provide the values of data members
    double getLength() {return length;}
    double getWidth() {return width;}
    double getHeight() {return height;}

    // Functions to set data member values
    void setHeight(double hvalue) {if(hvalue > 0) height = hvalue;}

  private:
    double length;
    double width;
    double height;
};

#endif
