// Program 5.5 Displaying numbers in scientific notation
#include <iostream>
#include <iomanip>
#include <limits>
using std::cout;
using std::endl;
using std::setprecision;
using std::numeric_limits;

int main() {
  const double pi = 3.14159265;
  cout << endl;

  for(double radius = .2 ; radius <= 3.0 ; radius += .2)
    cout << "radius = "
    << setprecision(numeric_limits<double>::digits10 + 1)
    << std::scientific << radius
         << "  area = "
         << std::setw(10) << setprecision(6)
         << std::fixed << pi * radius * radius
         << endl;
  return 0;
}
