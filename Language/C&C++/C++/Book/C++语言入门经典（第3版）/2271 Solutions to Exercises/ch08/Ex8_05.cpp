// Exercise 8.5 The function smaller() is similar to the function larger() that we saw in the chapter. Once you have updated the smaller of val1 and val2, it then becomes the larger!
#include <iostream>
#include <iomanip>
using std::cout;
using std::cin;
using std::endl;

long& smaller(long& m, long& n);
long& larger(long& m, long& n);


int main() {
  int count = 0;
  cout << "How many values in the Fibonacci sequence would you like? ";
  cin >> count;

  long n1 = 1L;  // First in sequence
  long n2 = 1L;  // Second in sequence
  cout << endl << std::setw(15) << n1
               << std::setw(15) << n2;
  
  for(int i = 2; i<count; i++) {
    if(i%5 == 0)
      cout << endl;
    smaller(n1, n2) = n1 + n2;
    cout << std::setw(15) << larger(n1, n2);
  }
  cout << endl;
  return 0;
}

// Returns the smaller of the two arguments as a reference
// This means this function can be used on the rhs of an assignment
long& smaller(long& m, long& n) {
  return m < n ? m : n;
}

// Returns the larger of the two arguments as a reference
// This means this function can be used on the rhs of an assignment
long& larger(long& m, long& n) {
  return m > n ? m : n;
}