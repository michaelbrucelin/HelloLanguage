// Program 5.11 Calculating an average in an indefinite loop
#include <iostream>
#include <cctype>
using std::cout;
using std::cin;
using std::endl;

int main() {
  char ch = 0;                         // Stores response to prompt for input
  int count = 0;                       // Counts the number of input values
  double temperature = 0.0;            // Stores an input value
  double average = 0.0;                // Stores the total and average

  for( ; ; ) {                         // Indefinite loop
    cout << "Enter a value: ";         // Prompt for input
    cin >> temperature;                // Read input value
    average += temperature;            // Accumulate total of values
    count++;                           // Increment value count

    cout << "Do you want to enter another? (y/n): ";
    cin >> ch;                         // Get response
    cout << endl;
    if(std::tolower(ch) == 'n')        // Check for no
      break;                           // if so end the loop
  }
  cout << endl
       << "The average temperature is " << average / count
       << endl;
  return 0;
}
