// Program 4.4 Using standard library character testing and conversion
#include <iostream>
#include <cctype>                   // Character testing and conversion
using std::cin;
using std::cout;
using std::endl;

int main() {
  char letter = 0;                  // Store input in here

  cout << endl
       << "Enter a letter: ";       // Prompt for the input
  cin >> letter;                    // then read a character
  cout << endl;

  if(std::isupper(letter)) {             // Test for uppercase letter
    cout << "You entered a capital letter."
         << endl;
    cout << "Converting to lowercase we get "
         << static_cast<char>(std::tolower(letter)) << endl;
    return 0;
  }

  if(std::islower(letter)) {             // Test for lowercase letter
    cout << "You entered a small letter."
         << endl;
    cout << "Converting to uppercase we get "
         << static_cast<char>(std::toupper(letter)) << endl;
    return 0;
  }
  cout << "You did not enter a letter." << endl;
  return 0;
}
