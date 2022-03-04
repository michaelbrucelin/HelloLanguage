// Program 7.1 The indirection operator in action
#include <iostream>
using std::cout;
using std::endl;

int main() {
  long number = 50L;
  long* pnumber;                               // Pointer declaration
  pnumber = &number;                           // Store the address of number
  cout << endl
       << "The value stored in the variable number is "
       << *pnumber
       << endl;
  return 0;
}
