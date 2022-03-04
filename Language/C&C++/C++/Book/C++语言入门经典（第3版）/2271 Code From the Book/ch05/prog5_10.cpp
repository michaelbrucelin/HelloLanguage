// Program 5.10 Controlling input with an infinite loop
#include <iostream>
#include <iomanip>
#include <cctype>
using std::cout;
using std::cin;
using std::endl;
using std::setw;

int main() {
  int table = 0;                                // Table size
  const int table_min = 2;                      // Minimum table size
  const int table_max = 12;                     // Maximum table size
  const int input_tries = 3;
  char ch = 0;                                  // Response to prompt

  do {
    for(int count = 1 ; ; count++) {            // Indefinite loop
      cout << endl
           << "What size table would you like ("
           << table_min << " to " << table_max << ")? ";
      cin >> table;                             // Get the table size
      cout << endl;

      // Make sure table size is within the limits
      if(table >= table_min && table <= table_max)
        break;                                  // Exit the input loop
      else if(count < input_tries)
        cout << "Invalid input - Try again.";
      else {
        cout << "Invalid table size entered - for the third time."
             << "\nSorry, only three goes - program terminated."
             << endl;
        exit(1);
      }
    }

        // Create the top line of the table
    cout << "     |";
    for(int i = 1 ; i <= table ; i++)
      cout << " " << setw(3) << i << " |";
    cout << endl; 

    // Create the separator row
    for(int i = 0 ; i <= table ; i++)
      cout << "------";
    cout << endl;

    for(int i = 1 ; i <= table ; i++) {     // Iterate over rows
      cout << " " << setw(3) << i << " |";   // Start the row

      // Output the values in a row
      for(int j = 1 ; j <= table ; j++)
        cout << " " << setw(3) << i*j << " |"; // For each col.
      cout << endl;                     // End the row
    }

    // Check if another table is required
    cout << endl << "Do you want another table (y or n)? ";
    cin >> ch;
    cout << endl;
  } while(std::tolower(ch) == 'y');

  return 0;
}
