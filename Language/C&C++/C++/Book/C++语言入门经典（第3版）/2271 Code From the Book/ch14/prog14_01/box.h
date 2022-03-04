// Box.h - Definition of the Box class
#ifndef BOX_H
#define BOX_H

class Box {
  public:
    Box(double aLength = 1.0, double aWidth = 1.0, double aHeight = 1.0); 
                                               // Constructor

    double volume() const;                     // Calculate Box volume

    double getLength()  const; 
    double getWidth() const;
    double getHeight()  const;

    bool operator<(const Box& aBox) const {    // Overloaded 'less-than' operator
      return volume() < aBox.volume();         // Defined inline
    }

  private:
    double length;
    double width;
    double height;
};
#endif
