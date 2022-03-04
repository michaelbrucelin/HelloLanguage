// Program 6.6 Concatenating strings
#include <iostream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string first;                                  // Stores the first name
  string second;                                 // Stores the second name

  cout << endl << "Enter your first name: ";
  cin >> first;                                  // Read first name

  cout << "Enter your second name: ";
  cin >> second;                                 // Read second name

  string sentence = "Your full name is ";        // Create basic sentence
  sentence += first + " " + second + ".";        // Augment with names

  cout << endl
       << sentence                               // Output the sentence
       << endl;
  cout << "The string contains "                 // Output its length
       << sentence.length()
       << " characters."
       << endl;

  return 0;
}
