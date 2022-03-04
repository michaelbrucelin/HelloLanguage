// Program 18.3 A better Array class template  File: prog18_03.cpp
#include "Box.h"
#include "Array.h"
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

int main() {
  try   {
    const int size = 21;                           // Number of array elements
    const int startValues = -10;                   // Index for first element
    const int endValues = startValues + size - 1;  // Index for last element

    Array<double> values(size, startValues);       // values[-10] to values[10]

    for(int i = startValues; i <= endValues ; i++) // Initialize the elements
      values[i] = i - startValues + 1;
    const int startData = startValues+5;           // Index for first element
    const int endData = endValues+5;               // Index for last element
    
    Array<double> data(size, startData);           // Data[-5] to Data[15]

    for(int j = startData, i = startValues ; i <= endValues ; i++, j++)  // Initialize
      data[j] = values[i];

    cout << endl << "Sums of pairs of elements: ";
    int lines = 0;
    for(int i = endData ; i >= startData ; i--)
      cout << (lines++ % 5 == 0 ? "\n" : "") 
           << std::setw(5) << data[i] + data[i - 1];
  }
  catch(const std::exception& ex) {
    cout << endl << typeid(ex).name() << " exception caught! "<< ex.what();
  }

  cout << endl;
  return 0;
}
