// Program 3.2 Finding the sizes of data types
#include <iostream>
using std::cout;
using std::endl;

int main() {
  // Output the sizes for integer types
  cout << endl 
       << "Size of type char is "
       << sizeof(char);
  cout << endl 
       << "Size of type short is "
       << sizeof(short);
  cout << endl 
       << "Size of type int is "
       << sizeof(int);
  cout << endl 
       << "Size of type long is "
       << sizeof(long);

  // Output the sizes for floating point types
  cout << endl 
       << "Size of type float is "
       << sizeof(float);
  cout << endl 
       << "Size of type double is "
       << sizeof(double);
  cout << endl 
       << "Size of type long double is "
       << sizeof(long double);
  cout << endl;
  return 0;
}
