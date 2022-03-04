// Box.h - Definition of the Box class
#ifndef BOX_H
#define BOX_H
class Box {
  public:
    Box(double aLength = 1.0, double aBreadth = 1.0, 
                              double aHeight = 1.0);  // Constructor

    double volume() const;                            // Calculate Box volume

    double getLength()  const;
    double getBreadth() const;
    double getHeight()  const;

    int compareVolume(const Box& otherBox) const;     // Compare volumes of boxes

  private:
    double length;
    double width;
    double height;
};
#endif
