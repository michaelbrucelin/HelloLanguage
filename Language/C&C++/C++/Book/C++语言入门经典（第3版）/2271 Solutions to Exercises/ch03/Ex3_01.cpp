//  Exercise 3.1 The potential for trouble here comes in the statement that calculates the reciprocal.
// If you write it as 1/denominator, the program won't work - integer division will take place,
// and the output will (nearly) always be 0. The solution is to write the literal as 1.0, 
// which is of type double, so that the division is carried out correctly.

#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  int denominator = 0;
  double reciprocal = 0;

  cout << "Enter a non-zero integer, and I'll calculate its reciprocal: ";
  cin >> denominator;

  reciprocal = 1.0/denominator;

  cout << "The reciprocal of " << denominator << " is " << reciprocal << endl;
  return 0;
}