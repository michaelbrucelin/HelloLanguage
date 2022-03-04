// Program 5.2 Using a do-while loop to control input
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  char ch = 0;                                // Stores response to prompt for input
  int count = 0;                              // Counts the number of input values
  double temperature = 0.0;                   // Stores an input value
  double average = 0.0;                       // Stores the total and average

  cout << endl;

  do {
    cout << "Enter a temperature reading: ";  // Prompt for input
    cin >> temperature;                       // Read input value

    average += temperature;                   // Accumulate total of values
    count++;                                  // Increment value count

    cout << "Do you want to enter another? (y/n): ";
    cin >> ch;                                // Get response
    cout << endl;
  } while(ch == 'y');

  /**********************************************
     You could replace the loop condition with: 

   } while(ch == 'y' || ch == 'Y');

  This will now accept a 'yes input in either 
  upper or lower case.

  If you add an #include directive for the 
  cctype header, you could also write the loop
  condition as: 

   } while(std::tolower(ch) == 'y');

  **********************************************/

   
  average /= count;                           // Calculate the average
  cout << "The average temperature is " << average
       << endl;
  return 0;
}
