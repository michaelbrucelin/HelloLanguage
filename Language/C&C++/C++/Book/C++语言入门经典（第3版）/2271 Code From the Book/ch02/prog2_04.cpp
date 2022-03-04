// Program 2.4 - Using const
#include <iostream>               
using std::cin;
using std::cout;
using std::endl;

int main() {
  const int inches_per_foot = 12;
  const int feet_per_yard = 3;
  int yards = 0;
  int feet = 0;
  int inches = 0;

  // Read the length from the keyboard
  cout << "Enter a length as yards, feet, and inches: ";
  cin >> yards >> feet >> inches;

  // Output the length in inches
  cout << endl
       << "Length in inches is "
       << inches + inches_per_foot * (feet + feet_per_yard * yards)
       << endl;
  return 0;
}
