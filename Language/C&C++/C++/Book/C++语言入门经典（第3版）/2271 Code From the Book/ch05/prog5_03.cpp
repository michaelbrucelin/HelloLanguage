// Program 5.3 Using a for loop
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  int sum = 0;                        // Accumulates the sum of integers
  int count = 0;                      // The number to sum

  cout << "How many integers do you want to sum? ";
  cin >> count;

  for(int i = 1 ; i <= count ; i++)
    sum += i;

  cout << endl
       << "The sum of the integers from 1 to " << count 
       << " is " << sum << endl;

  return 0;
}
