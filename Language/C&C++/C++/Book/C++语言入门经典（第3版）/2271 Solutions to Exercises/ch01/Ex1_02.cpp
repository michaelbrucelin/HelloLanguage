// Exercise 1.2 Writing the line "Hello World" to the screen using hexadecimal escape sequences.

#include <iostream>
using std::cout;
using std::endl;

int main() {
  cout << endl
       << "\x48\x65\x6C\x6C\x6F\x20\x57\x6F\x72\x6C\x64"
       << endl;

  return 0;
}