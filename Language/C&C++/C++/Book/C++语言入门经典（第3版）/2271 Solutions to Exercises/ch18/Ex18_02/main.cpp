// Exercise 18.2 Exercising the LinkedList template class
// This program reverses the text that is entered
#include "LinkedListT.h"
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

  LinkedList<string> words;                // List to store words

  // Extract words and store in the list
  string separators(" ,.\"?!;:");          // Separators between words
  int start = 0;                           // Start of a word
  int end = 0;                             // separator position after a word
  while(string::npos != (start = text.find_first_not_of(separators, start))) {
    end = text.find_first_of(separators, start+1);
    words.addTail(&text.substr(start,end-start));
    start = end;
  }

  // List the words in reverse order 5 to a line
  string* pStr = words.getTail();
  int count = 0;                           // Word counter
  while(pStr) {
    if(count++ % 5 == 0)
      cout << endl;
    cout << *pStr << ' ';
    pStr = words.getPrevious();
  }

  cout << endl;
  return 0;
}