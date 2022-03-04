// Box.h Definition of the Box class
#ifndef BOX_H
#define BOX_H

class Box {
  public:
    // Constructor
    Box(double lengthValue = 1.0, double widthValue = 1.0, double heightValue = 1.0);

    // Function to calculate the volume of a box
    double volume();

    // Friend function
    friend double boxSurface(const Box& theBox);

  private:
    double length;
    double width;
    double height;
};

#endif
