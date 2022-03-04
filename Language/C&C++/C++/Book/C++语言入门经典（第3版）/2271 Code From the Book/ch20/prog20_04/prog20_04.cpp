// Program 20.4 Computing an average with template arrays  File: prog20_04.cpp
#include <iostream>
#include <vector>
using std::cout;
using std::endl;
using std::vector;

template <typename Array>
double average(Array a, long count) { // Array can be a pointer or an iterator
  double sum = 0.0;
  for (long i = 0; i<count; ++i) 
    sum += a[i];
  return sum/(count==0.0 ? 1.0 : count);                  
} 

int main() {
  double temperature[] = { 10.5, 20.0, 8.5 }; 

  // second argument is now the count
  cout << "array average = " 
       << average(temperature, sizeof temperature/sizeof temperature[0]) 
       << endl;

  vector<int> sunny;
  sunny.push_back(7);  
  sunny.push_back(12);  
  sunny.push_back(15);
  cout << sunny.size() << " months on record" << endl; 
  cout << "average number of sunny days: "; 
  cout << average(sunny.begin(), sunny.end() - sunny.begin()) << endl;
  return 0;
}
