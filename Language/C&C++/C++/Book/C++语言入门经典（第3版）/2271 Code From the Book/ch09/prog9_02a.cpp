// Program 9.2a Overloading a function with const reference parameters
#include <iostream>
using std::cout;
using std::endl;
double larger(double a, double b);
long larger(const long& a, const long& b);

int main() {
  double a_double = 1.5, b_double = 2.5;
  cout << endl;
  cout << "The larger of double values " 
       << a_double << " and " << b_double <<" is " 
       << larger(a_double, b_double) << endl;
 
  int a_int = 15, b_int = 25;
  cout << "The larger of int values "
       << a_int << " and " << b_int <<" is " 
       << larger(static_cast<long>(a_int), static_cast<long>(b_int))
       << endl;
  return 0;
}

// Function to return the larger of two floating point values
double larger(double a, double b) {
  cout << "double larger() called" << endl;
  return a>b ? a : b;
}

// Return the larger of two long references
long larger(const long& a, const long& b) {
  cout << "long ref larger() called" << endl;
  return a>b ? a : b;
}
