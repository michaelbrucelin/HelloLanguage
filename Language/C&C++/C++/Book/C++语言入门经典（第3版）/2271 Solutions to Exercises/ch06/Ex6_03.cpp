// Exercise 6.3 Extension to Program 6.9. 
//  Here, we take a copy of the original string to work on. 
// The first for loop converts upper case letters to lower case.
// Then we perform the search for the substring "had" as before.

#include <iostream>
#include <cctype>
#include <string>
using std::cout;
using std::endl;
using std::string;

int main() {
  // The string to be searched
  string text = "Smith, where Jones had had \"had had\", had had \"had\"."
                " \"Had had\" had had the examiners' approval.";

  string word = "had";                // Substring to be found

  cout << endl << "The string is: " << endl << text << endl;

  string textCopy = text;

  for(int i = 0 ; i < textCopy.length() ; i++)
    textCopy[i] = std::tolower(textCopy[i]);

  // Count the number of occurrences of word in textCopy
  int count = 0;                      // Count of substring occurrences

  for(int index = 0 ; (index = textCopy.find(word, index)) != string::npos ;
                                                                  index += word.length(), count++)
    ;

  cout << "Your text contained "
       << count << " occurrences of \""
       << word  << "\", ignoring case."
       << endl;

  return 0;
}