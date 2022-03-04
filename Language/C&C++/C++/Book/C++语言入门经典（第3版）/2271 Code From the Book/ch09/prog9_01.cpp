// Program 9.1 Overloading a function
#include <iostream>
using std::cout;
using std::endl;

// Prototypes for two different functions 
double larger(double a, double b);             
long larger(long a, long b);                


int main() {
  double a_double = 1.5, b_double = 2.5;
  float a_float = 3.5f, b_float = 4.5f;
  long a_long = 15L, b_long = 25L;
  cout << endl;
  cout << "The larger of double values " 
       << a_double << " and " << b_double <<" is " 
       << larger(a_double, b_double) << endl;
  cout << "The larger of float values "
       << a_float << " and " << b_float <<" is " 
       << larger(a_float, b_float) << endl;
  cout << "The larger of long values "
       << a_long << " and " << b_long <<" is " 
       << larger(a_long, b_long) << endl;
return 0;
}

// Function to return the larger of two floating point values
double larger(double a, double b) {
  cout << "double larger() called" << endl;
  return a>b ? a : b;
}

// Function to return the larger of two integer values
long larger(long a, long b) {
  cout << "long larger() called" << endl;
  return a>b ? a : b;
}
