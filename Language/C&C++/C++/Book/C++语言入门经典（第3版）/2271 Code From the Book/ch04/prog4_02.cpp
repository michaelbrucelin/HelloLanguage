// Program 4.2 Using an if statement
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  cout << "Enter an integer between 50 and 100: ";

  int value = 0;
  cin >> value;

  if(value < 50)
    cout << "The value is invalid - it is less than 50." << endl;

  if(value > 100)
    cout << "The value is invalid - it is greater than 100." << endl;

  cout << "You entered " << value << endl;
  return 0;
}
