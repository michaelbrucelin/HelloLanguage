// Program 4.6 Combining logical operators
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  int age = 0;                      // Age of the prospective borrower
  int income = 0;                   // Income of the prospective borrower
  int balance = 0;                  // Current bank balance

  // Get the basic data
  cout << endl << "Please enter your age in years: ";
  cin >> age;

  cout << "Please enter your annual income in dollars: ";
  cin >> income;

  cout << "What is your current account balance in dollars: ";
  cin >> balance;
  cout << endl;

  // We only lend to people over 21, who make
  // over $25,000 per year, or have over
  // $100,000 in their account, or both.

  if(age >= 21 && (income > 25000 || balance > 100000)) {
    // OK, you are good for the loan - but how much?
    // This will be the lesser of twice income and half balance

    int loan = 0;                   // Stores maximum loan amount
    if(2 * income < balance / 2)
      loan = 2 * income;
    else
      loan = balance / 2;

    cout << "You can borrow up to $"
         << loan
         << endl;
  }
  else
    cout << "Sorry, we are out of cash today."
         << endl;
  return 0;
}
