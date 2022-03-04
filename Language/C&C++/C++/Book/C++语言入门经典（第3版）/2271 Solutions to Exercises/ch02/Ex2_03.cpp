// Exercise 2.3 Converting a length in inches to feet-and-inches.
#include <iostream>
using std::cin;
using std::cout;

int main() {
  const int inches_per_foot= 12;

  long length_inches = 0L;

  cout << "This program converts inches into feet-and-inches.\n";
  cout << "Please enter the number of inches: ";
  cin >> length_inches;

  long feet = length_inches / inches_per_foot;
  long inches = length_inches % inches_per_foot;

  cout << "\nIn " << length_inches << " inches there are "
       << feet << " feet and " << inches << " inch(es).\n";


  return 0;
}