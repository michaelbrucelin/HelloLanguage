// Program 8.4 Modifying the original value of a function argument
#include <iostream>
using std::cout;
using std::endl;

double change_it(double* pointer_to_it);  // Function prototype

int main() {
  double it = 5.0;
  double result = change_it(&it);         // Now we pass the address

  cout << "After function execution, it = " << it     << endl
       << "Result returned is "             << result << endl;

  return 0;
}

// Function to modify an argument and return it
double change_it(double* pit) {
  *pit += 10.0;                          // This modifies the original it
  cout << endl
       << "Within function, *pit = " << *pit << endl;
  return *pit;
}
