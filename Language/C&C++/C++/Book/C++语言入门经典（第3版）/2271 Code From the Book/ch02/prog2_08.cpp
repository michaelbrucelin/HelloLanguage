// Program 2.8 Experimenting with floating point output
#include <iostream>
#include <iomanip>
using std::setprecision;
using std::fixed;
using std::scientific;
using std::cout;
using std::endl;

int main() {
  float value1 = 0.1f;
  float value2 = 2.1f;
  value1 -= 0.09f;                        // Should be 0.01
  value2 -= 2.09f;                        // Should be 0.01

  cout << setprecision(14) << fixed;      // Change to fixed notation
  cout << value1 - value2 << endl;        // Should output zero

  cout << setprecision(5) << scientific;  // Set scientific notation
  cout << value1 - value2 << endl;        // Should output zero

  return 0;
}
