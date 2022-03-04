// Exercise 5.1 Squaring odd numbers
#include <iostream>
#include <iomanip>
using std::cout;
using std::cin;
using std::endl;
using std::setw;

int main() {
  int limit = 0;
  cout << "Enter the upper limit for squared odd numbers: ";
  cin >> limit;
  for (int i = 1; i <= limit; i += 2)
    cout << setw(4) << i << " squared is " << setw(8) << i * i <<  endl;

  return 0;
}