// Exercise 11.1 A currency converter    File: currency.h
// currency.h Definition for Currency structure
#ifndef CURRENCY_H
#define CURRENCY_H

// Structure representing a currency
struct Currency {
  char name[20];                    // Currency name
  double amount;                    // An amount in this currency
  double rate;                      // Value of 1 unit of this currency in US dollars
  char code[4];                     // Currency code - 3 characters e.g. "USD"

  double convert(Currency amount);  // Convert amount to this currency
  void set_amount(double amount);   // Set an amount in this currency
  void show();                      // Display the amount of this currence
};

#endif