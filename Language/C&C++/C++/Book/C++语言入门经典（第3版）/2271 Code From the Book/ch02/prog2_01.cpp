// Program 2.1 - Calculating with integer constants
#include <iostream>                       // For output to the screen
using std::cout;
using std::endl;

int main() {  
  cout << 10 + 20               << endl;  // Output is  30
  cout << 10 - 5                << endl;  // Output is   5
  cout << 10 - 20               << endl;  // Output is -10

  cout << 10 * 20               << endl;  // Output is 200
  cout << 10/3                  << endl;  // Output is  3
  cout << 10 % 3                << endl;  // Output is  1
  cout << 10 % -3               << endl;  // Output is  1
  cout << -10 % 3               << endl;  // Output is -1
  cout << -10 % -3              << endl;  // Output is -1

  cout << 10 + 20/10 - 5        << endl;  // Output is  7
  cout << (10 + 20)/(10 - 5)    << endl;  // Output is  6
  cout << 10 + 20/(10 - 5)      << endl;  // Output is 14
  cout << (10 + 20)/10 - 5      << endl;  // Output is  -2

  cout << 4*5/3%4 + 7/3         << endl;  // Output is   4
  return 0;                               // End the program
}
