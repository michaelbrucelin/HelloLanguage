// Program 12.2 Using a class constructor    File: prog12_02.cpp
#include <iostream>
using std::cout;
using std::endl;

// Class to represent a box
class Box {
  public:
    double length;
    double width;
    double height;

    // Constructor
    Box(double lengthValue, double widthValue, double heightValue) {
      cout << "Box constructor called" << endl;
      length = lengthValue;
      width = widthValue;
      height = heightValue;
    }

    // Function to calculate the volume of a box
    double volume() {
      return length * width * height;
    }
};

int main() {
  Box firstBox(80.0, 50.0, 40.0);

  // Calculate the volume of the box
  double firstBoxVolume = firstBox.volume();
  cout << endl;
  cout << "Size of first Box object is "
       << firstBox.length  << " by "
       << firstBox.width << " by "
       << firstBox.height
       << endl;
  cout << "Volume of first Box object is " << firstBoxVolume
       << endl;

  return 0;
}
