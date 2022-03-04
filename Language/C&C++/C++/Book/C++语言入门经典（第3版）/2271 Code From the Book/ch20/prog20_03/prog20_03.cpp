// Program 20.3 Computing the average function with template iterators
//  File: prog20_03.cpp
#include <iostream>
#include <vector> 
using std::cout;
using std::endl;
using std::vector;

template <typename Iter> 
double average(Iter begin, Iter end) {    // improves average(double*a,double*end)
  double sum = 0.0;
  int count = end-begin;  
  while( begin != end )
    sum += *begin++;
  return sum/(count == 0.0 ? 1.0 : count);        
} 

int main() {
  double temperature[] = { 10.5, 20.0, 8.5 }; 
  cout << "array average = " 
       << average(temperature,
                      temperature+sizeof temperature/sizeof temperature[0]) 
       << endl;

  vector<int> sunny;
  sunny.push_back(7);  
  sunny.push_back(12);  
  sunny.push_back(15);
  cout << sunny.size() << " months on record" << endl; 
  cout << "average number of sunny days: "; 
  cout << average(sunny.begin(), sunny.end()) << endl; 

  return 0;
}
