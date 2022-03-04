// Box.h
#ifndef BOX_H
#define BOX_H

class Box {
  public:
    Box(double lengthValue = 1.0, double widthValue = 1.0,
                                                   double heightValue = 1.0);

    // Function to calculate the volume of a Box object
    virtual double volume() const = 0;

  protected:
    double length;
    double width;
    double height;
};
#endif
