// Program 20.8 Averaging values from Integer  File: prog20_08.cpp
#include <iostream>
#include "Integer.h"
using std::cout;
using std::endl;

template <typename Iter> 
double average(Iter a, Iter end) { 
  double sum = 0.0;
  int count = 0;  
  for( ; a != end ; ++count)
    sum += *a++;
  return sum/count;             // Lets bad things happen when count==0
} 

int main() {
  Integer first(1);
  Integer last(11);
  cout << "The average of the integers from " << *first << " to " << *last-1;
  cout << " is " << average(first, last) << endl;
  return 0;
}
