// Program 8.2 Calculating powers - rearranged
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

double power(double x, int n);   // Prototype for power function

int main() {
  cout << endl;

  // Calculate powers of 8 from -3 to +3
  for(int i = -3 ; i <= 3 ; i++) 
    cout << std::setw(10) << power(8.0, i);

  cout << endl;
  return 0;
}

// Function to calculate x to the power n
double power(double x, int n) {
  double result = 1.0;
  if(n >= 0)
    for(int i = 0 ; i < n ; i++)
      result *= x;
  else
    for(int i = 0 ; i < -n ; i++)
      result /= x;
  return result;
}