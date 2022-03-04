// Program 3.1 Using Explicit Casts
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  const long feet_per_yard = 3;
  const long inches_per_foot = 12;

  double yards = 0.0;                       // Length as decimal yards
  long yds = 0;                             // Whole yards
  long ft = 0;                              // Whole feet
  long ins = 0;                             // Whole inches

  cout << "Enter a length in yards as a decimal: ";
  cin >> yards;

  // Get the length as yards, feet and inches
  yds = static_cast<long>(yards);
  ft = static_cast<long>((yards - yds) * feet_per_yard);
  ins = static_cast<long>(yards * feet_per_yard * inches_per_foot) % inches_per_foot;

  cout << endl
       << yards << " yards converts to "
       << yds   << " yards "
       << ft    << " feet "
       << ins   << " inches.";

  cout << endl;
  return 0;
}
