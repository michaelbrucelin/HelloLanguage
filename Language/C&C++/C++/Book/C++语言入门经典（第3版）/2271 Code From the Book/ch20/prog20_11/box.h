// Box.h definition of the Box class
#ifndef BOX_H
#define BOX_H
#include <iostream>
using std::cout;
using std::ostream;

class Box {
  public:
    Box(double lv = 1.0, double wv = 1.0, double hv = 1.0) :
                                    length(lv), width(wv), height(hv) {}

    double volume() const { return length*width* height; }
    bool operator<(const Box& x) const { return volume() < x.volume(); }

    friend ostream& operator<<(ostream& out, const Box& box) {
      out << "(" << box.length << "," << box.width << "," << box.height << ")";
      return out;
    }

  private:
    double length;
    double width;
    double height;
};
#endif
