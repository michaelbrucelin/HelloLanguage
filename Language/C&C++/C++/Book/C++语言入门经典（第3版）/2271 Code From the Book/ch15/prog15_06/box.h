// Box.h - Definition of the Box class
#ifndef BOX_H
#define BOX_H
class Box {
  public:  
    Box();                                    // Default constructor
    Box(double lv, double wv, double hv);     // Constructor
    Box(const Box& aBox);                     // Copy constructor
    ~Box();                                   // Destructor

  protected:
    double length;
    double width;
    double height;
};
#endif
