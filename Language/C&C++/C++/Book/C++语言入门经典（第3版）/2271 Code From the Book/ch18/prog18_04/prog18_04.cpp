// Program 18.4 Using a stack defined by nested class templates  File prog18_04.cpp
#include "Stacks.h"
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  const char* words[] = {"The", "quick", "brown", "fox", "jumps"};
  Stack<const char*> wordStack;             // A stack of null terminated strings

  for(int i = 0 ; i < 5 ; i++)
    wordStack.push(words[i]);

  Stack<const char*> newStack(wordStack);   // Create a copy of the stack

  // Display the words in reverse order
  while(!newStack.isEmpty())
    cout << newStack.pop() << " ";
  cout << endl;

  // Reverse wordStack onto newStack
  while(!wordStack.isEmpty())
    newStack.push(wordStack.pop());

  // Display the words in original order
  while(!newStack.isEmpty())
    cout << newStack.pop() << " ";
  cout << endl;

  cout << endl << "Enter a line of text:" << endl;
  string text;
  getline(cin, text);                       // Read a line into the string object

  Stack<const char> characters;             // A stack for characters

  for(size_t i = 0 ; i < text.length() ; i++)
    characters.push(text[i]);               // Push the string characters onto the stack

  cout << endl;
  while(!characters.isEmpty())
    cout << characters.pop();               // Pop the characters off the stack

  cout << endl;
  return 0;
}
