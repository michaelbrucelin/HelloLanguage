// Program 7.5 Sorting strings using pointers
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string text;                                            // The string to be sorted
  const string separators = " ,.\"\n";                    // Word delimiters
  const int max_words = 1000;                             // Maximum number of words
  string words[max_words];                                // Array to store the words
  string* pwords[max_words];                              // Array of pointers to the words

  // Read the string to be searched from the keyboard
  cout << endl << "Enter a string terminated by #:" << endl;
  getline(cin, text, '#');

  // Extract all the words from the text
  int start = text.find_first_not_of(separators);         // Word start index
  int end = 0;                                            // End delimiter index
  int word_count = 0;                                     // Count of words stored
  while(start != string::npos && word_count < max_words) {
    end = text.find_first_of(separators, start + 1);
    if(end == string::npos)                               // Found a separator?
      end = text.length();                                // No, so set to last + 1

    words[word_count] = text.substr(start, end - start);  // Store the word
    pwords[word_count] = &words[word_count];              // Store the pointer
    word_count++;                                         // Increment count

    // Find the first character of the next word
    start = text.find_first_not_of(separators, end + 1);
  }

  // Sort the words in ascending sequence by direct insertion
  int lowest = 0;                                         // Index of lowest word

  for(int j = 0; j < word_count - 1; j++) {
    lowest = j;                                           // Set lowest

    // Check current against all the following words
    for(int i = j + 1 ; i < word_count ; i++)
      if(*pwords[i] < *pwords[lowest])                    // Current is lower?
        lowest = i; 

    if(lowest != j) {          // Then swap pointers...
      string* ptemp = pwords[j];                          // Save current
      pwords[j] = pwords[lowest];                         // Store lower in current
      pwords[lowest] = ptemp;                             // Restore current
    }
  }

  // Output the words in ascending sequence
  for(int i = 0 ; i < word_count ; i++)
    cout << endl << *pwords[i];

  cout << endl;
  return 0;
}
