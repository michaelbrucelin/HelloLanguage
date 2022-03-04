// Exercise 11.1 Currency converter.     File: currency.cpp
#include <iostream>
#include <iomanip>
#include "currency.h"

// Display a currency amount with two decimal places
void Currency::show() {
  std::cout << std::fixed << std::setprecision(2) << amount << " " << code;
  }

// Sets the amount for the current currency
void Currency::set_amount(double value){
  if(value == 0.0)                      // Can't have a zero amount
    amount = 1.0;
  else
    amount = value;
}

// Convert the amount of the current currency the currency of the argument
double Currency::convert(Currency currency) {
  return amount*rate/currency.rate;
}