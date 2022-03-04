// Program 2.7 Floating point errors
#include <iostream>
using std::cout;
using std::endl;

int main() {
  float value1 = 0.1f;
  float value2 = 2.1f;
  value1 -= 0.09f;                   // Should be 0.01
  value2 -= 2.09f;                   // Should be 0.01
  cout << value1 - value2 << endl;   // Should output zero
  return 0;
}
