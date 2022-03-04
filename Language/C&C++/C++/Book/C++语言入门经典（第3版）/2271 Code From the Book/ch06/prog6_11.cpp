// Program 6.11 Replacing words in a string
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  // Read the string from the keyboard
  string text;
  cout << endl << "Enter a string terminated by #:" << endl;
  std::getline(cin, text, '#');

  // Get the word to be replaced
  string word;
  cout << endl << "Enter the word to be replaced: ";
  cin >> word;

  // Get the replacement
  string replacement;
  cout << endl << "Enter the replacement word: ";
  cin >> replacement;

  if(word == replacement) {
    cout << endl 
         << "The word and its replacement are the same." << endl
         << "Operation aborted." << cout;
    exit(1);
  }

  // Find the start of the first occurrence of word
  size_t start = text.find(word);

  // Now find and replace all occurrences of word
  while(start != string::npos) {
    text.replace(start, word.length(), replacement);         // Replace word
    start = text.find(word, start + replacement.length());
  }

  cout << endl 
       << "Your string is now:" << endl 
       << text << endl;

  return 0;
}