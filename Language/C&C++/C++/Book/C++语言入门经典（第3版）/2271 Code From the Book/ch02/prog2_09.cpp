// Program 2.9 – Handling character values
#include <iostream>           
using std::cin;
using std::cout;
using std::endl;

int main() {
  char ch = 0;
  int ch_value = 0;

  // Read a character from the keyboard
  cout << "Enter a character: ";
  cin >> ch;
  ch_value = ch;                  // Get integer value of character

  cout << endl
       << ch << " is " << ch_value;

  ch_value = ++ch;                // Increment ch and store as integer
  cout << endl
       << ch << " is " << ch_value
       << endl;

  return 0;
}
