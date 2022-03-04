// Program 20.5 Taking the average of values from a stream  File: prog20_05.cpp
#include <iostream>
#include <iterator>             // For the istream_iterator<> template
using std::cout;
using std::endl;
using std::cin;
using std::istream_iterator;
template <typename Iter> 
double average (Iter begin, Iter end) { 
  double sum = 0.0;
  int count = 0;  
  for( ; begin != end ; count++)
    sum += *begin++;
  return sum/(count == 0 ? 1 : count);        
} 

int main() {
  cout << "Enter some real numbers separated by whitespace - spaces, " << endl
       << "tabs or newline. Then press the special key sequence " << endl
       << "that marks the end-of-file (Ctrl-Z on a PC)" << endl;

  double av = average(istream_iterator<double>(cin), istream_iterator<double>());
  cout << "The average value is " << av << endl;
return 0;
}
