// Program 2.2 - Working with integer variables
#include <iostream>              // For output to the screen
using std::cout;
using std::endl;

int main() {  
  int apples = 10;             // Definition for the variable apples
  int children = 3;            // Definition for the variable children

  // Calculate fruit per child
  cout << endl                   // Start on a new line
       << "Each child gets "     // Output some text
       << apples/children        // Output number of apples per child
       << " fruit.";             // Output some more text

  // Calculate number left over
  cout << endl                   // Start on a new line
       << "We have "             // Output some text
       << apples % children      // Output apples left over
       << " left over.";         // Output some more text

  cout << endl;
  return 0;                      // End the program
}
