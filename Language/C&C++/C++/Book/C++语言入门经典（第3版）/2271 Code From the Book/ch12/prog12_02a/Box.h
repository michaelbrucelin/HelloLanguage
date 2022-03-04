// Box.h
#ifndef BOX_H
#define BOX_H

class Box {
  public:
    double length;
    double width;
    double height;

    // Constructor
    Box(double lengthValue, double widthValue, double heightValue);

    // Function to calculate the volume of a box
    double volume();
};

#endif
