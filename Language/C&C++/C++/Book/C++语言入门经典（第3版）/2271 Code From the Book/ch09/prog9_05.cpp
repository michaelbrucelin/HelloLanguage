// Program 9.5 Exercising pointers to functions
#include <iostream>
using std::cout;
using std::endl;

long sum(long a, long b);               // Function prototype
long product(long a, long b);           // Function prototype

int main() {
  long (*pDo_it)(long, long) = 0;       // Pointer to function declaration

  pDo_it = product;
  cout << endl
       << "3*5 = " << pDo_it(3, 5);      // Call product through a pointer

  pDo_it = sum;                         // Reassign pointer to sum()
  cout << endl
       << "3 * (4+5) + 6 = " 
       << pDo_it(product(3, pDo_it(4, 5)), 6);  // Call thru a pointer twice

  cout << endl;
  return 0;
}

// Function to multiply two values
long product(long a, long b) {
  return a*b;
}

// Function to add two values
long sum(long a, long b) {
  return a+b;
}
