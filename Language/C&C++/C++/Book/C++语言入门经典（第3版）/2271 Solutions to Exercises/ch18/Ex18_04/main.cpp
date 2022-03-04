// Exercise 18.4 Exercising the SparseArray class template for an array of arrays
#include "SparseArrayT.h"
#include <string>
#include <iostream>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string text;                             // Stores input prose or poem
  cout << "\nEnter a poem or prose over one or more lines."
       << "Terminate the input with #:\n";
  getline(cin, text, '#');

  SparseArray< SparseArray<string> > arrays; // Sparse array of arrays of strings
  string letters("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

  // Extract words and store in the appropriate list
  string word;
  string separators(" \n\t,.\"?!;:");          // Separators between words
  int start = 0;                           // Start of a word
  int end = 0;                             // separator position after a word
  while(string::npos != (start = text.find_first_not_of(separators, start))) {
    end = text.find_first_of(separators, start+1);
    word = text.substr(start,end-start);
    arrays[letters.find(toupper(word[0]))].insert(&word);
    start = end;
  }

  // List the words in order 5 to a line
  for(int i = 0 ; i<26 ; i++) {
    int j = 0;
    int count = 0;                           // Word counter
    while((word = arrays[i][j++]).length()) {
      if(count++ % 5 == 0)
        cout << endl;
      cout << word << ' ';
    }
  }

  cout << endl;
  return 0;
}