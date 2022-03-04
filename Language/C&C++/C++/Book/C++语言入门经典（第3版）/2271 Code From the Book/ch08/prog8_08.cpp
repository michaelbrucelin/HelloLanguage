// Program 8.8 Using reference parameters
#include <iostream>
using std::cout;
using std::endl;

int larger(int& m, int& n);

int main() {
  int value1 = 10;
  int value2 = 20;
  cout << endl << larger(value1, value2) << endl;

  return 0;
}

// Function to the larger of two integers
int larger(int& m, int& n) {
  return m > n ? m : n;              // Return the larger value
}
