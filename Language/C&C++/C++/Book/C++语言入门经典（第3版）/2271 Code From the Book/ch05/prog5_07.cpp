// Program 5.7 Demonstrating the comma operator
#include <iostream>
#include <iomanip>
using std::cout;
using std::cin;
using std::endl;
using std::setw;

int main() {
  int count = 0;
  cout << endl << "What upper limit would you like? ";
  cin >> count;

  cout << endl
       << "integer"                    // Output column headings
       << "     sum"
       << "       factorial"
       << endl;

  for(long n = 1, sum = 0, factorial = 1 ;
                     sum += n, factorial *= n, n <= count ; n++)
    cout << setw(4) << n   << "    "
         << setw(7) << sum << " "
         << setw(15) << factorial
         << endl;
  return 0;
}
