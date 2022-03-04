// Program 9.2 Overloading a function with reference parameters
#include <iostream>
#include <iomanip>
using namespace std;

double larger(double a, double b);
long& larger(long& a, long& b);


int main()
{
  cout << endl;
  cout << "Larger of 1.5 and 2.5 is " << larger(1.5, 2.5) << endl;
 
  int value1 = 35;
  int value2 = 45;

  cout << "Larger of " << value1 << " and " << value2 << " is " 
       << larger(static_cast<long>(value1), static_cast<long>(value2))
       << endl;

  return 0;
}

// Function to return the larger of two floating point values
double larger(double a, double b)
{
  cout << " double version. ";
  return a>b ? a : b;
}

// Return the larger of two long references
long& larger(long& a, long& b)
{
  cout << " long ref version. ";
  return a>b ? a : b;
}
