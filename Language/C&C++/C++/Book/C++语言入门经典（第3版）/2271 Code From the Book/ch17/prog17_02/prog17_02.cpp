// Program 17.2 Throwing exceptions in nested try blocks  File: prog17_02.cpp
#include <iostream>
using std::cout;
using std::endl;

void throwIt(int i) {
  throw i;                                // Throws the parameter value
}

int main() {
  for(int i = 0 ; i <= 5 ; i++)   {
    try {
      cout << endl << "outer try: ";
      if(i == 0)
        throw i;                          // Throw int exception

      if(i == 1)
        throwIt(i);                       // Call the function that throws int

      try {                               // Nested try block
        cout << endl << " inner try: ";
        if(i == 2)
          throw static_cast<long>(i);     // Throw long exception

        if(i == 3)
          throwIt(i);                     // Call the function that throws int
      }                                   // End nested try block
      catch(int n) {
        cout << endl << "Catch int for inner try. "
             << "Exception " << n;
      }

      cout << endl << "  outer try: ";

      if(i == 4)
        throw i;                          // Throw int
      throwIt(i);                         // Call the function that throws int
    }
    catch(int n) {
      cout << endl << "Catch int for outer try. "
           << "Exception " << n;
    }
    catch(long n) {
      cout << endl << "Catch long for outer try. "
           << "Exception " << n;
    }
  }

  cout << endl;
  return 0;
}
