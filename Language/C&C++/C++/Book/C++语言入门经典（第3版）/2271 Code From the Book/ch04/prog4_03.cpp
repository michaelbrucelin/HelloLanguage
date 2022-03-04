// Program 4.3 Using a nested if
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  char letter = 0;                      // Store input in here

  cout << "Enter a letter: ";           // Prompt for the input
  cin >> letter;                        // then read a character

  if(letter >= 'A') {                   // Test for 'A' or larger
    if(letter <= 'Z') {                 // Test for 'Z' or smaller
      cout << "You entered an uppercase letter."
           << endl;
      return 0;
    }
  }

  if(letter >= 'a')                     // Test for 'a' or larger
    if(letter <= 'z') {                 // Test for 'z' or smaller
      cout << "You entered a lowercase letter."
           << endl ;
      return 0;
    }
  cout << "You did not enter a letter." << endl;
  return 0;
}
