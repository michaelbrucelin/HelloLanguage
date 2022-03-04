// Exercise 18.3 Exercising the SparseArray class template with the LinkedList class template
// Add the SparseArrayT.h and LinkedListT.h files from ex18.1 and ex18.2 to this example.
#include "SparseArrayT.h"
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

  SparseArray< LinkedList<string> > lists; // Sparse array of linked lists
  string letters("ABCDEFGHIJKLMNOPQRSTUVWXYZ");

  // Extract words and store in the appropriate list
  string word;                             // Stores a word
  string separators(" \n\t,.\"?!;:");      // Separators between words
  int start = 0;                           // Start of a word
  int end = 0;                             // separator position after a word
  while(string::npos != (start = text.find_first_not_of(separators, start))) {
    end = text.find_first_of(separators, start+1);
    word = text.substr(start,end-start);
    lists[letters.find(toupper(word[0]))].addTail(&word);
    start = end;
  }

  // List the words in order 5 to a line
  string* pStr;
  for(int i = 0 ; i<26 ; i++) {
    pStr = lists[i].getHead();

    int count = 0;                           // Word counter
    while(pStr) {
      if(count++ % 5 == 0)
        cout << endl;
      cout << *pStr << ' ';
      pStr = lists[i].getNext();
    }
  }
  cout << endl;
  return 0;
}