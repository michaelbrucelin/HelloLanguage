// Exercise 8.4 Using reverse() from Ex 8.2 to reverse a command line argument. 
#include <iostream>
#include <string>
using std::cout;
using std::endl;
using std::string;

string reverse(string str1);

int main(int argc, char* argv[]) {
  switch(argc-1) {
    case 2: 
      for(int i = 1; i < argc; i++)
      cout << "Argument " << i << " is " << argv[i] << endl;
      cout << "argument 2 reversed is : \"" << reverse(argv[2]) << "\"" << endl;
      break;
    default: 
      cout << "You entered the incorrect number of arguments. " << endl
           << "Please enter 2 arguments. " << endl;
  }
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