// Program 4.1 Comparing data values
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  char first = 0;                       // Stores the first character
  char second = 0;                      // Stores the second character

  // Prompt for and read in the first character
  cout << "Enter a character: ";
  cin >> first;

  // Prompt for and read in the second character
  cout << "Enter a second character: ";
  cin >> second;

  cout << "The value of the expression first < second is: "
       << (first < second)
       << endl
       << "The value of the expression first == second is: "
       << (first == second)
       << endl;

  return 0;
}
