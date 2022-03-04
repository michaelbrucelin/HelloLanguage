// Program 10.1 Accessing External Variables prog10_01.cpp
#include <iostream>
#include <string>
#include <iomanip>
using std::cout;
using std::endl;
using std::string;

// Declare external variables
extern float phi;
extern const double pi;
extern const string days[];
extern int count;

int main() {
  cout << std::setprecision(3) << std::fixed;
  cout << endl
       << "To 3 decimal places..." << endl;

  cout << "...a circle with a diameter of phi has an area of " 
       << pi*phi*phi/4
       << endl;

  cout << "...phi squared is "         << phi*phi << endl;
  cout << "...in fact, phi+1 is also " << phi+1   << endl;

  cout << "Value of count is " << count << endl;

  count += 3;
  cout << "Today is " << days[count] << endl;
  return 0;
}
