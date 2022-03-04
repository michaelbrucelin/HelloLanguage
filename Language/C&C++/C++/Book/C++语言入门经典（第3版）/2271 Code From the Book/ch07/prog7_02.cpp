// Program 7.2 Exercising pointers
#include <iostream>
using std::cout;
using std::endl;

int main() {
  long* pnumber;                        // Pointer declaration
  long number1 = 55L;
  long number2 = 99L;                   // A couple of variables

  pnumber = &number1;                   // Store address in pointer
  *pnumber += 11;                       // Increment number1 by 11
  cout << endl
       << "number1 = "     << number1
       << "   &number1 = " << pnumber
       << endl;

  pnumber = &number2;                   // Change pointer to address of number2
  number1 = *pnumber * 10;              // 10 times number2

  cout << "number1 = "     << number1
       << "   pnumber = "  << pnumber
       << "   *pnumber = " << *pnumber
       << endl;

  return 0;
}
