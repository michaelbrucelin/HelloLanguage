// Exercise 8.2 Reversing the order of a string of characters. 
/******************************************************************
The reverse() function works with an argument of type string, or a
C-style string terminated with '\0'.
*******************************************************************/
#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

string reverse(string str1);

int main() {
  string sentence;
  cout << "Enter a sequence of characters, then press 'Enter': " << endl;
  getline(cin, sentence);

  cout << endl 
       << "Your sequence in reverse order is: " << endl;
  cout << reverse(sentence) << endl;

  cout << "Here is a demonstration of reverse() working with a C-style string"
       << endl;
      

  char stuff[] = "abcdefg";  // C-style string
  cout << endl << "The original string is: \"" << stuff << "\"" << endl
    << "Reversed it becomes: \"" << reverse(stuff) << "\"" << endl;
  
  return 0;
}

// Reverse a string in place
// The code here is working with a copy of the argument
// so the original is not affected.
string reverse(string str) {
  char temp = 0;
  for(int i=0; i < str.length()/2; i++) {
    temp = str[i];
    str[i] = str[str.length()-i-1];
    str[str.length()-i-1] = temp;
  }
  return str;
}