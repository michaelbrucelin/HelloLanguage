// Program 6.4 Analyzing the letters in a string
#include <iostream>
#include <cctype>
using std::cout;
using std::cin;
using std::endl;

int main() {
  const int maxlength = 100;                 // Array dimension
  char text[maxlength] = {0};                // Array to hold input string

  cout << endl << "Enter a line of text:" << endl;

  // Read a line of characters including spaces
  cin.getline(text, maxlength);

  cout << "You entered:" << endl << text << endl;

  int vowels = 0;                            // Count of vowels
  int consonants = 0;                        // Count of consonants
  for(int i = 0 ; text[i] != '\0' ; i++)
    if(std::isalpha(text[i]))                // If it is a letter
      switch(std::tolower(text[i])) {        // Test lowercase version
        case 'a': case 'e': case 'i': 
        case 'o': case 'u':
          vowels++;                          // It is a vowel
          break;
        default:
          consonants++;                      // It is a consonant
      }

  cout << "Your input contained "
       << vowels     << " vowels and "
       << consonants << " consonants."
       << endl;

  return 0;
}
