// Program 17.6 Rethrowing exceptions  File: prog17_06.cpp
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
      catch(Trouble& rT) {         // Inner handler
        if(typeid(rT) == typeid(Trouble))
          cout << "Trouble object caught: " << rT.what() << endl;
        else
          throw;                                    // Rethrow current exception
      }
    }
    catch(Trouble& rT) {        // Outer handler
      cout << typeid(rT).name() << " object caught: " << rT.what() << endl;
    }

    cout << "End of the for loop (after the catch blocks) - i is " << i << endl;
  }

  cout << endl;
  return 0;
}
