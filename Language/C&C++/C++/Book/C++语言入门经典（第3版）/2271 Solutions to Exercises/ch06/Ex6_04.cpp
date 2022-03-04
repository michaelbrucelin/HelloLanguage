// Exercise 6.4 Searching for and replacing a substring of a string with another string. 

#include <iostream>
#include <string>
#include <cctype>
using  std::cout;
using  std::cin;
using  std::endl;
using  std::string;

int main() {
  string text;                               // The string to be searched
  cout << "Enter the text that is to be searched terminated by #:" << endl;
  std::getline(cin, text, '#');
  string textcopy = text;                    // Make a copy of the string
  // Convert copy to lowercase
  for(int i = 0 ; i<textcopy.length() ; i++)
    textcopy[i] = std::tolower(textcopy[i]);

  string word;                               // Word to be found
  cout << "Enter a word that is to be found in the string : ";
  cin >> word;

  string wordcopy = word;                   // Make a copy of the word
  // Convert copy to lowercase
  for(int i = 0 ; i<wordcopy.length() ; i++)
    wordcopy[i] = std::tolower(wordcopy[i]);

  // Create string with the same number of asterisks as there are in word
  string asterisks = word;
  asterisks.replace(0, asterisks.length(), asterisks.length(), '*');

  cout << "Each occurrence of \"" << word 
       << "\" will be replaced by " << asterisks << "." << endl;


  // Search for wordcopy within textcopy object
  // but replace by asterisks in text
  int position = 0;
  while((position = textcopy.find(wordcopy, position)) != string::npos) {
    // We have to check that the characters before and after the word found
    // are not alphabetic, but we need to take care not to use index values
    // that are illegal - hence all the ifs.
    if(position==0) { 
      if(!std::isalpha(textcopy[position+word.length()]))
        text.replace(position, word.length(), asterisks);
    }else if(position+word.length()==text.length()) {
      if(!std::isalpha(textcopy[position-1]))
        text.replace(position, word.length(), asterisks);
    } else {
      if(!std::isalpha(textcopy[position-1]) && !std::isalpha(textcopy[position+word.length()]))
        text.replace(position, word.length(), asterisks);
    }
    position += word.length();
  }
 
  cout << endl << "After processing the original string is now:" << endl
       << text << endl;

  return 0;
}