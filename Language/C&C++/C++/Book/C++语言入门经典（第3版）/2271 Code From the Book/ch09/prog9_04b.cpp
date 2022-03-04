// Program 9.4b Using an overloaded function template 
#include <iostream>
using std::cout;
using std::endl;

template<class T> T larger(T a, T b);             // Function template prototype
long* larger(long* a, long* b);                   // overloaded function
template <class T> T larger (const T array[], int count); // Overloaded template prototype

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

  cout << "Larger of "   << a_long << " and " << b_long << " is " 
       << *larger(&a_long,&b_long)
       << endl;

  double x[] = { 10.5, 12.5, 2.5, 13.5, 5.5 };

  cout << "Largest element has the value " 
       << larger(x, sizeof x/sizeof x[0]) 
       << endl;

return 0;
}

// Template for functions to return the larger of two values
template <class T> T larger(T a, T b) {
  cout << "standard version " << endl;
  return a>b ? a : b;
}

// Overloaded function definition
long* larger(long* a, long* b) {
  cout << "overloaded version for long* " << endl;
  return *a>*b ? a : b;
}

// Overloaded template definition
template <class T> T larger (const T array[], int count) {
  cout << "template overload version for arrays " << endl;
  T result = array[0];
  for(int i = 1 ; i < count ; i++)
    if(array[i] > result)
      result = array[i];
  return result;
}
