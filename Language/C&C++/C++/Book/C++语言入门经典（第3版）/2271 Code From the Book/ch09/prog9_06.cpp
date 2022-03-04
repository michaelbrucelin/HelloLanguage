// Program 9.6 A pointer to a function as an argument
#include <iostream>
using std::cout;
using std::endl;

// Function prototypes
double squared(double);           
double cubed(double);    
double sum_array(double array[], int len, double (*pfun)(double));

int main() {
  double array[] = { 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 7.5 };
  int len = sizeof array/sizeof array[0];

  cout << endl
       << "Sum of squares = "
       << sum_array(array, len, squared)
       << endl;

  cout << "Sum of cubes = "
       << sum_array(array, len, cubed)
       << endl;
return 0;
}

// Function for a square of a value
double squared(double x) {
   return x*x;
}

// Function for a cube of a value
double cubed(double x) {
   return x*x*x;
}

// Function to sum functions of array elements
double sum_array(double array[], int len, double (*pfun)(double)) {
   double total = 0.0;     // Accumulate total in here

   for(int i = 0 ; i < len ; i++)
      total += pfun(array[i]);
   return total;
}
