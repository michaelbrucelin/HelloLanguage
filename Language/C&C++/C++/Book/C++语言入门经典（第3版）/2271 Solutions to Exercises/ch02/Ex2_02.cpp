// Exercise 2.2 This time, the user is also prompted to enter an integer that we can
// subsequently use to control the program's output. 
// Note that setprecision() doesn't alter the calculated value of areaOfCircle;
// it's only used to control how this value is output.

#include <iostream>
#include <iomanip>
using std::cout;
using std::cin;
using std::endl;
using std::setprecision;


int main() {
  // Initialize constant variables
  const float pi = 3.1416f;

  float radius = 0;
  float areaOfCircle = 0;
  int sigFigs = 0;

  cout << "This program will compute the area of a circle." << endl
       << "We assume that the value of pi is " << pi << "." << endl;

  cout << "Please enter the radius: ";
  cin >> radius;

  cout << "Please enter the desired precision of the output (significant figures): ";
  cin >> sigFigs;

  areaOfCircle = pi * radius * radius;

  cout << endl 
       << "The area of the circle is approximately equal to "
       << setprecision(sigFigs)
       << areaOfCircle << " square units." << endl;

  return 0;
}