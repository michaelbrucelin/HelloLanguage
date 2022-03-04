// Program 2.1A - Producing neat output
#include <iostream>                                   // For output to the screen
#include <iomanip>                                    // For manipulators
using std::cout;
using std::endl;
using std::setw;

int main() {
  cout << setw(10) << 10 + 20            << endl;  // Output is  30
  cout << setw(10) << 10 - 5             << endl;  // Output is   5
  cout << setw(10) << 10 - 20            << endl;  // Output is -10

  cout << setw(10) << 10 * 20            << endl;  // Output is 200
  cout << setw(10) << 10/3               << endl;  // Output is   3
  cout << setw(10) << 10 % 3             << endl;  // Output is   1
  cout << setw(10) << 10 % -3            << endl;  // Output is   1, the remainder
  cout << setw(10) << -10 % 3            << endl;  // Output is  -1, the remainder
  cout << setw(10) << -10 % -3           << endl;  // Output is  -1, the remainder
  cout << setw(10) << 10 + 20/10 - 5     << endl;  // Output is   7
  cout << setw(10) << (10 + 20)/(10 - 5) << endl;  // Output is   6

  cout << setw(10) << 10 + 20/(10 - 5)   << endl;  // Output is  14
  cout << setw(10) << (10 + 20)/10 - 5   << endl;  // Output is - 2
  cout << setw(10) << 4*5/3%4 + 7/3      << endl;  // Output is   4
  return 0;                                        // End the program
}
