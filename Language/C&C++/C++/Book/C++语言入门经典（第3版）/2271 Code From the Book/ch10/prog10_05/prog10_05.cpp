// Program 10.5 Using a function template in a namespace extension   File: prog10_05.cpp
#include <iostream>
#include <iomanip>
#include "normal.h"

using compare::max;                    // Using declaration for max
using compare::min;                    // Using declaration for min
using std::cout;
using std::endl;

int main() {
  double data[] = {1.5, 4.6, 3.1, 1.1, 3.8, 2.1};
  int numbers[] = {23, 2, 14, 56, 42, 12, 1, 45};

  cout << endl;

  const int dataSize = sizeof data/sizeof data[0];
  cout << "Minimum double is " << min(data, dataSize) << endl; 
  cout << "Maximum double is " << max(data, dataSize) << endl; 

  const int numbersSize = sizeof numbers/sizeof numbers[0];
  cout << "Minimum integer is " << min(numbers, numbersSize) << endl; 
  cout << "Maximum integer is " << max(numbers, numbersSize) << endl;

  double newData[numbersSize];                      // Array for result
  compare::normalize(numbers, newData, numbersSize);// Normalize 

  // Output the normalized array values    
  for(int i = 0 ; i < numbersSize ; i++) {
    if(i%5 == 0)
      cout << endl;
    cout << std::setw(12) << newData[i];
  }
  cout << endl;
  return 0;
}
