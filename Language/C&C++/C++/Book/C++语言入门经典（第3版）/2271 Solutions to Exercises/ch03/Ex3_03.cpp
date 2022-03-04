// Exercise 3.3 Using a bitwise operator to affect the binary representation of an integer.
// The simplest way to invert the last bit of a number is to exclusive-OR the number with 1.
// The effect of changing the value of the last bit may depend on your computer,
// but on mine this program adds 1 to an even integer, and subtracts 1 from an odd integer.

#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  const int maskValue = 1;

  int value = 0;
  int result = 0;

  cout << "Please enter an integer value: ";
  cin >> value;

  result = value ^ maskValue;
  cout << "The value of " << value << " with its lowest bit inverted is " 
       << result << endl;

  return 0;
}