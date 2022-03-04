// Program 3.3 Finding maximum and minimum values for data types
#include <limits>
#include <iostream>
using std::cout;
using std::endl;
using std::numeric_limits;

int main() {
  cout << endl
       << "The range for type short is from "
       << numeric_limits<short>::min()
       << " to "
       << numeric_limits<short>::max();
  cout << endl
       << "The range for type int is from "
       << numeric_limits<int>::min()
       << " to "
       << numeric_limits<int>::max();
  cout << endl
       << "The range for type long is from "
       << numeric_limits<long>::min()
       << " to "
       << numeric_limits<long>::max();
  cout << endl
       << "The range for type float is from "
       << numeric_limits<float>::min()
       << " to "
       << numeric_limits<float>::max();
  cout << endl
       << "The range for type double is from "
       << numeric_limits<double>::min()
       << " to "
       << numeric_limits<double>::max();
  cout << endl
       << "The range for type long double is from "
       << numeric_limits<long double>::min()
       << " to "
       << numeric_limits<long double>::max();
  cout << endl;
  return 0;
}
