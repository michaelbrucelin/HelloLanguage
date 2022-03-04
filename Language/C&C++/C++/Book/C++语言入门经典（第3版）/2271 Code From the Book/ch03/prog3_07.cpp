// Program 3.7 Using the scope resolution operator
#include <iostream>
using std::cout;
using std::endl;

int count1 = 100;              // Global version of count1

int main() {                      // Function scope starts here
  int count1 = 10;
  int count3 = 50;
  cout << endl << "Value of outer count1 = " << count1;
  cout << endl << "Value of global count1 = " << ::count1;

  {                                // New block scope starts here...
    int count1 = 20;               // This hides the outer count1
    int count2 = 30;
    cout << endl << "Value of inner count1 = " << count1;
    cout << endl << "Value of global count1 = " << ::count1;
    count1 += 3;                   // This changes the inner count1
    count3 += count2;
  }                                // ...and ends here.

  cout << endl
       << "Value of outer count1 = " << count1
       << endl
       << "Value of outer count3 = " << count3;

  // cout << endl << count2;   // Uncomment to get an error
  cout << endl;
  return 0;
}                              // Function scope ends here
