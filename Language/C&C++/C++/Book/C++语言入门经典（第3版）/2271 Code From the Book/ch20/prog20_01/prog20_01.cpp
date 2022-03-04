// Program 20.1 A quick comparison of array and vector  File: prog20_01.cpp
#include <iostream> 
#include <vector>
using std::cout;
using std::endl;
using std::vector;

int main() {
  int a[10];                           // C++ array declaration 
//  vector<int> v(10);                   // Equivalent STL vector declaration 
   vector<int> v(a, a+sizeof a/sizeof a[0]);                   // Equivalent STL vector declaration 
 
  cout << "size of 10 element array:  " << sizeof a << endl;
  cout << "size of 10 element vector: " << sizeof v << endl;

//  for (int i = 0; i < 10; ++i)  
 //   a[i] = v[i] = i;

  int a_sum = 0, v_sum = 0;
  for (int i = 0; i < 10; ++i) {
    a_sum += a[i];
    v_sum += v[i];
  }

  cout << "sum of 10 array  elements: " << a_sum << endl;
  cout << "sum of 10 vector elements: " << v_sum << endl;

  vector<int> vnew(a, a+sizeof a/sizeof a[0]);               // Initialized from an interval
  int vnew_sum = 0;
  for (int i = 0; i < vnew.size(); ++i)
   vnew_sum += vnew[i];  
   cout << "sum of 10 new vector elements: " << v_sum << endl;

   return 0;
}
