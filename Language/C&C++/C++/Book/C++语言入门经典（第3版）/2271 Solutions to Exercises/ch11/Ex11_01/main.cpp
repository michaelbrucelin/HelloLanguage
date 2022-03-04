// Exercise 11.1 A currency converter
#include "currency.h"
#include <iostream>
#include <iomanip>
#include <cctype>
using std::cout;
using std::endl;
using std::cin;

int main() {
  // Array of standard currencies
  Currency currencies[] = {
                    {"US dollars",       1.0, 1.0,    "USD" },
                    {"UK pounds",        1.0, 1.69,   "GBP" },
                    {"Russian roubles",  1.0, 0.033,   "RUR" },
                    {"Japanese yen",     1.0, 0.0084, "JPY" },
                    {"Polish zlotys",    1.0, 0.26,   "PLN" },
                        };

  int currency_count = sizeof currencies/sizeof currencies[0];  // Number of currencies

  int from_currency = 0;        // Index of currency converted from
  int to_currency = 0;          // Index of currency converted to
  double amount = 0.0;          // Amount to be converted
  char answer = 0;              // Y/N input response

  cout << endl << "Currencies available for conversion are: " << endl;
  for(int i = 0 ; i<currency_count ; i++)
    cout << std::setw(3) << i+1 << ". " << currencies[i].name << endl;

  do {
    // Get from currency number and check it's within range
    while(true) {
      cout << endl << "Select the currency you want to convert from by number: ";
      cin >> from_currency;
      if(from_currency<1 || from_currency>currency_count)
        cout << "Invalid input - try again." << endl;
      else
        break;
    }

    // Get to currency number and check it's within range
    while(true) {
      cout << endl << "Select the currency you want to convert to by number: ";
      cin >> to_currency;
      if(from_currency == to_currency || to_currency<1 || to_currency>currency_count)
        cout << "Invalid input - try again." << endl;
      else
        break;
    }
    --from_currency;       // Decrement so we canuse as an index value to the array
    --to_currency;         // Decrement so we canuse as an index value to the array

    while(true) {
      cout << endl << "Enter the amount of " 
           << currencies[from_currency].name << " that you want to convert to "
           << currencies[to_currency].name << ": ";
       cin >> amount;
       if(amount <= 0.0)
         cout << "The amount cannot be zero or negative - try again." << endl;
       else
         break;
    }


    currencies[from_currency].set_amount(amount);
    currencies[to_currency].set_amount(currencies[from_currency].convert(currencies[to_currency]));
    currencies[from_currency].show();
    cout << " is worth ";
    currencies[to_currency].show();
    cout << endl;
    cout << endl << "Do you want another conversion (y/n)? ";
    cin >> answer;
  } while(std::tolower(answer) == 'y');
  
  
 
  return 0;
}