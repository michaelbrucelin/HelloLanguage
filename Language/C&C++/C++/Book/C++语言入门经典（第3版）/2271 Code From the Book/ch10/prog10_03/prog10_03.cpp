// Program 10.3 Using functions in a namespace    File prog10_03.cpp
#include <iostream>
#include "compare.h"

using compare::max;                    // Using declaration for max
using compare::min;                    // Using declaration for min
using std::cout;
using std::endl;

int main() {
  double data[] = {1.5, 4.6, 3.1, 1.1, 3.8, 2.1};
  const int dataSize = sizeof data/sizeof data[0];

  cout << endl;
  cout << "Minimum double is " << min(data, dataSize) << endl; 
  cout << "Maximum double is " << max(data, dataSize) << endl; 

  return 0;
}
