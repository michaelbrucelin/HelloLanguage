// Exercise 5.2 Summing integers and calculating the average
#include <iostream>
#include <iomanip>
#include <cctype>
using std::cout;
using std::cin;
using std::endl;

int main() {
  char ch = 0;
  int n = 0;
  int count = 0;
  long total = 0L;
  cout << "Enter the the first integer: ";
  while(true) {
   cin >> n;
   total += n;
   ++count;
   cout << "Do you want to enter another(y/n)?";
   cin >> ch;
   if(std::tolower(ch) == 'n')
     break;
   else
     cout << "Enter an integer: ";
  }
  cout << "The total is " << total << endl
    << "The average is " << std::setw(10) << std::setprecision(2)
       << std::fixed << (static_cast<double>(total)/count) << endl;
  return 0;
}