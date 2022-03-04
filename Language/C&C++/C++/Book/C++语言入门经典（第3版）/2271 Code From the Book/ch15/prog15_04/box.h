// Box.h - Definition of the Box class
#ifndef BOX_H
#define BOX_H
class Box {
  public:  
    Box();                                    // Default constructor
    Box(double lv, double wv, double hv);     // Constructor

  protected:
    double length;
    double width;
    double height;
};
#endif
