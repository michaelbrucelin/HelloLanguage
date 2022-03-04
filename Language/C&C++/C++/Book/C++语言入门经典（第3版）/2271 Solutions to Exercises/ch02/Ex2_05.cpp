// Exercise 2.5 Finding the largest of two integers without comparing them.
#include <iostream>
using std::cin;
using std::cout;

int main() {

  long a = 0L;
  long b = 0L;

  cout << "Enter a positive integer: ";
  cin >> a;
  cout << "Enter another different positive integer: ";
  cin >> b;

  // The trick is to find arithmetic expressions for each of the larger
  // and the smaller of the two integers
  long larger = (a*(a/b) + b*(b/a))/(a/b + b/a);
  long smaller = (b*(a/b) + a*(b/a))/(a/b + b/a);
  cout << "\nThe larger integer is " << larger << "."
       << "\nThe smaller integer is " << smaller << ".\n";

  return 0;
}