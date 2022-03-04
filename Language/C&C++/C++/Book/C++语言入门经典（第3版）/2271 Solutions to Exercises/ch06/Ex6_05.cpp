// Exercise 6.5 Check for anagrams.
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string word1;
  string word2;

  cout << "Enter the first word: ";
  cin >> word1;
  cout << "Enter the second string: ";
  cin >> word2;

  // Test the pathological case of the strings being different lengths
  if(word1.length() != word2.length()) {
    cout << "The words are different lengths, so they can't be anagrams!" << endl;
    return 0;
  }

  // Loop over all the characters in word1
  for (int i = 0 ; i < word1.length() ; i++)
    // Loop over all the characters in word2
    for (int j = 0 ; j < word2.length() ; j++)
      if(tolower(word2[j]) == tolower(word1[i])) {
        word2.erase(j, 1);   // Character found so erase from word2
        break;
      }

  cout << "The two words are"
       << (word2 == "" ? " " : " not ")
       << "anagrams of one another." 
       << endl;

  return 0;
}