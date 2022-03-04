// Program 4.5 Using the if-else
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  long number = 0;                  // Store input here
  cout << "Enter an integer less than 2 billion: ";
  cin >> number;
  cout << endl;

  if(number % 2L == 0)              // Test remainder after division by 2
    cout << "Your number is even."  // Here if remainder is 0
         << endl;
  else
    cout << "Your number is odd."   // Here if remainder is 1
         << endl;
  return 0;
}
