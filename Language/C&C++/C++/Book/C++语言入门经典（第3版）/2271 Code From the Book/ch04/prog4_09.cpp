// Example 4.9 Multiple case actions
#include <iostream>
#include <cctype>
using std::cin;
using std::cout;
using std::endl;

int main() {
  char letter = 0;
  cout << endl
       << "Enter a letter: ";
  cin >> letter;

  if(std::isalpha(letter))
    switch(std::tolower(letter)) {
       case 'a': case 'e': case 'i': case 'o': case 'u':
         cout << endl << "You entered a vowel." << endl;
         break;
       default:
         cout << endl << "You entered a consonant." << endl;
    }
  else
    cout << endl << "You did not enter a letter." << endl;

  return 0;
}
