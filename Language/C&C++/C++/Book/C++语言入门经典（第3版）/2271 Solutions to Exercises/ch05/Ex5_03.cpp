// Exercise 5.3 Using a do-while loop to count characters
#include <iostream>
using std::cout;
using std::cin;
using std::endl;
int main() {
  long count= 0L;
  char ch;

  cout << "Please enter a sequence of characters terminated by '#':" << endl;

  // We have to read at least one character - even if it's '#' - so do-while is best
  do {
    cin >> ch;
    ++count;
  } while (ch != '#'); 

  // We do not count '#' as a character, so count must be adjusted
  --count;
  cout << "You entered " << count 
       << " characters (not counting spaces and the terminal #)." << endl;

  return 0;
}