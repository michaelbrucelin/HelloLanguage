// Exercise 7.2 Dynamically allocating memory to store an array of floating-point values.
#include <iostream>
#include <cmath>
using std::cout;
using std::cin;
using std::endl;

int main() {
  int size = 0;
  cout << "Enter the size of the floating-point array: ";
  cin >> size;

  double* array = new double[size];

  // Initialize the array.
  double temp = 0.0;     // working variable
  for(int i = 0 ; i < size ; i++) {
    temp = i+1.0;                  // We convert to double to avoid range problems with integers
    *(array+i) = 1.0/(temp*temp);  // The denominator would be a problem as integer arithmetic when i is large
  }

  double sum = 0.0;
  for(int i = 0 ; i < size ; sum += *(array+i++))
    ;

  cout << "Result = " << std::sqrt(6.0*sum) << endl;

  delete[] array;
  return 0;
}