// Program 9.7 recursive version of x to the power n
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

double power(double x, int n);

int main() {
  cout << endl;

  // Calculate powers of 8 from -3 to +3
  for( int i = -3 ; i <= 3 ; i++) 
    cout << std::setw(10) << power(8.0, i);

  cout << endl;
  return 0;
}

// Recursive function to calculate x to the power n
double power(double x, int n) {
  if(0 == n)
    return 1.0;
  if(0 < n)
    return x*power(x, n-1);

  return 1.0/power(x, -n);
}
