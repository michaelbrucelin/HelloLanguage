// Program 17.1 Throwing and catching exceptions  File: prog17_01.cpp
#include <iostream>
using std::cout;
using std::endl;

int main() {
  cout << endl;
  for(int i = 0 ; i < 7 ; i++) {
    try {
      if(i < 3)
        throw i;
      cout << " i not thrown - value is " << i << endl;

      if(i > 5)
        throw "Here is another!";
      cout << " End of the try block." << endl;
    }
    catch(const int i) {          // Catch exceptions of type int
      cout << " i caught - value is " << i << endl;
    }
    catch(const char* pmessage) { // Catch exceptions of type char*
      cout << "  \"" << pmessage << "\" caught" << endl;
    }

    cout << "End of the for loop body (after the catch blocks) - i is " << i << endl;
  }

  return 0;
}
