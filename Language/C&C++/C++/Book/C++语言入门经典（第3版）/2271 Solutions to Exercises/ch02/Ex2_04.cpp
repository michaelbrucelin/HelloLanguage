// Exercise 2.4 Calculating the height of a tree
#include <iostream> 
#include <iomanip>
#include <cmath>
using std::cin;
using std::cout;
using std::endl;
int main() {
  const double inches_per_foot = 12.0;
  const double pi = 3.14159265;
  const double pi_degrees = 180.0;
  double d_feet = 0.0;
  double d_inches = 0.0;
  double angle = 0.0;
  double eye_height = 0.0;

  cout << "Enter the distance from the tree in feet and inches: ";
  cin >> d_feet >> d_inches;
  double distance = d_feet + d_inches/inches_per_foot;

  cout << "Enter the angle of the top of the tree in degrees: ";
  cin >> angle;
  angle *= pi/pi_degrees;     // Convert angle to radians

  cout << "Enter your eye height from the ground in inches: ";
  cin >> eye_height;
  eye_height /= inches_per_foot;   // Convert to feet
  double height = eye_height + distance*std::tan(angle); // Tree height in feet
  double height_feet = std::floor(height);
  double height_inches = std::floor(inches_per_foot*(height-height_feet)+0.5);

  cout << "\nThe height of the tree is " 
       << height_feet << " feet "
       << height_inches << " inches.\n";             
return 0;
}