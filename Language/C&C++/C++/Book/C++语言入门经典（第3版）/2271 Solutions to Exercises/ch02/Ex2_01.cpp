// Exercise 2.1 Calculate the area of a circle of given radius. 
// The value of pi is constant, and should not be changed within the program,
// so we recognize this by declaring it as a const.

#include <iostream>
using std::cout;
using std::cin;
using std::endl;

int main() {
  // Initialize constant variables
  const float pi = 3.1416f;

  float radius = 0;
  float areaOfCircle = 0;

  cout << "This program will compute the area of a circle." << endl
       << "We assume that the value of pi is " << pi << "." << endl;

  cout << "Please enter the radius: ";
  cin >> radius;

  areaOfCircle = pi * radius * radius;

  cout << endl
       << "The area of the circle equals " 
       << areaOfCircle << " square units." << endl;

  return 0;
}