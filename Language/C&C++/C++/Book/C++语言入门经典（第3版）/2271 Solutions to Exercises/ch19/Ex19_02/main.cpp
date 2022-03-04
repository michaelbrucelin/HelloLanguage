// Exercise 19.2 Using the Time class with an overloaded extraction operator.
// The extraction operator is implemented as a friend of the Time class
#include "Time.h"
#include <iostream>
using std::cout;
using std::cin;
using std::endl;

int main() {
  Time period1;
  Time period2;
  cout << "\nEnter a time as hours:minutes:seconds, and press Enter: ";
    cin >> period1;
  cout << "\nEnter another time as hours:minutes:seconds, and press Enter: ";
    cin >> period2;
  cout << "\nPeriod 1 is " << period1
       << "\nPeriod 2 is " << period2
       << endl;
  return 0;
}