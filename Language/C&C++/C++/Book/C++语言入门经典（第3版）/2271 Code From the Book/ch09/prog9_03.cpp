// Program 9.3 Using a function template
#include <iostream>
using std::cout;
using std::endl;

template<class T> T larger(T a, T b);      // Function template prototype

int main() {
  cout << endl;
  cout << "Larger of 1.5 and 2.5 is " << larger(1.5, 2.5) << endl;
  cout << "Larger of 3.5 and 4.5 is " << larger(3.5, 4.5) << endl;
 
  int a_int = 35;
  int b_int = 45;
  cout << "Larger of " << a_int << " and " << b_int << " is "
       << larger(a_int, b_int)
       << endl;

  
  long a_long = 9;
  long b_long = 8;
  cout << "Larger of "   << a_long << " and " << b_long << " is "
       << larger(a_long, b_long)
       << endl;

return 0;
}

// Template for functions to return the larger of two values
template <class T> T larger(T a, T b) {
  return a>b ? a : b;
}
