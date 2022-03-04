// Program 5.4 Floating point control in a for loop
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

int main() {
  const double pi = 3.14159265;
  cout << endl;

  for(double radius = .2 ; radius <= 3.0 ; radius += .2)
    cout << "radius = " << std::setw(6) << radius
         << "  area = " << std::setw(12) << pi * radius * radius
         << endl;
  return 0;
}
