// Program 17.7 Catching any exception  File: prog17_07.cpp
#include <iostream>
#include "MyTroubles.h"
using std::cout;
using std::endl;

int main() {
  Trouble trouble;
  MoreTrouble moreTrouble;
  BigTrouble bigTrouble;

  cout << endl;
  for(int i = 0 ; i < 7 ; i++) {
    try {
      try {
        if(i < 3)
          throw trouble;
        if(i < 5)
          throw moreTrouble;
        else
          throw bigTrouble;
      }
      catch(...) {        // Inner handler
        cout << "We caught something! Let's rethrow it." << endl;
        throw;                                      // Rethrow current exception
      }
    }
    catch(Trouble& rT) {  // Outer handler
      cout << typeid(rT).name() << " object caught: " << rT.what() << endl;
    }

    cout << "End of the for loop (after the catch blocks) - i is " << i << endl;
  }

  cout << endl;
  return 0;
}
