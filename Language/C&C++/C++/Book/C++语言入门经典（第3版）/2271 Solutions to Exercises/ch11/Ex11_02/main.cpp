// Exercise 11.2 A currency converter with optional user-entered currencies
// Only this file has been changed. currency.h and currency.cpp are the same as for Ex 11.1
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
  const int standard_currency_count = sizeof currencies/sizeof currencies[0]; // Number of standard currencies
  int currency_count = standard_currency_count;
  const int max_currencies = 7;                   // Maximum total number of currencies

  Currency* pCurrencies[max_currencies];          // Create an array of pointers to currencies

  // Copy the addresses of the standard currenciers to the pointer array
  for(int i = 0 ; i<currency_count ; i++)
    pCurrencies[i] = &currencies[i];

  int from_currency = 0;                          // Index of currency converted from
  int to_currency = 0;                            // Index of currency converted to
  double amount = 0.0;                            // Amount to be converted
  char answer = 0;                                // Y/N input response
 
  cout << endl << "Currencies available for conversion are: " << endl;
  for(int i = 0 ; i<currency_count ; i++)
    cout << std::setw(3) << i+1 << ". " << currencies[i].name << endl;

  // Add user-defined currencies by creatring them in the free store
  while(true) {
    cout << "Do you want to add another currency(y/n)? ";
    cin >> answer;
    if(std::tolower(answer) == 'n')
      break;
    pCurrencies[currency_count] = new Currency;
    pCurrencies[currency_count]->set_amount(1.0);

    cout << "Enter the currency name: ";
    cin >> pCurrencies[currency_count]->name;

    cout << "Enter the three character currency code (e.g. USD): ";
    cin >> pCurrencies[currency_count]->code;

    cout << "Enter the value of 1 " << pCurrencies[currency_count]->code 
         << " in US dollars: "; 
    cin >> pCurrencies[currency_count]->rate;

    if(++currency_count == max_currencies) {
      cout << " Maximum number of currencies reached." << endl;
      break;
    }
  }

  cout << endl << "Currencies now available for conversion are: " << endl;
  for(int i = 0 ; i<currency_count ; i++)
    cout << std::setw(3) << i+1 << ". " << pCurrencies[i]->name << endl;

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
           << pCurrencies[from_currency]->name << " that you want to convert to "
           << pCurrencies[to_currency]->name << ": ";
       cin >> amount;
       if(amount <= 0.0)
         cout << "The amount cannot be zero or negative - try again." << endl;
       else
         break;
    }

    pCurrencies[from_currency]->set_amount(amount);
    pCurrencies[to_currency]->set_amount(pCurrencies[from_currency]->convert(*pCurrencies[to_currency]));
    pCurrencies[from_currency]->show();
    cout << " is worth ";
    pCurrencies[to_currency]->show();
    cout << endl;
    cout << endl << "Do you want another conversion (y/n)? ";
    cin >> answer;
  } while(std::tolower(answer) == 'y');
  
  // Now delete the Currency objects from the free store
  if(currency_count>standard_currency_count)
    for(int i = standard_currency_count; i<currency_count ; i++)
      delete pCurrencies[i];
 
  return 0;
}