// Program 5.1 Using a while loop to sum integers
#include <iostream>
#include <iomanip>
using std::cin;
using std::cout;
using std::endl;

int main() {
  int n = 0;
  cout << "How many integers do you want to sum: ";
  cin >> n;

  int sum = 0;                       // Stores the sum of integers
  int i = 1;                         // Stores the integer to add to the total
  cout << "Values are: " << endl; 
  while(i <= n) {
    cout << std::setw(5) << i;      // Output current value of i
    if(i%10 == 0)
      cout << endl;                 // Newline after ever 10 values
    sum += i++;
  }

  cout << endl << "Sum is " << sum << endl;  // Output final sum
  return 0;
}
