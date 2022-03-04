// Exercise 9.3 Accessing the trig functions via a pointer to function. 
/********************************************************************************
The trig functions in the cmath header file expect the argument to be in radians;
you could extend the program by having the user enter a value in degrees
and converting it. 
*********************************************************************************/
#include <iostream>
#include <cmath>
using std::cout;
using std::cin;
using std::endl;

double calc(const double& value, double (*pTrigFun)(double));

int main() {
  double value = 0;
  
  cout << "Enter a value, in radians: ";
  cin >> value;

  double (*pTrigFunctions[])(double) = {std::sin, std::cos, std::tan};
  
  cout << " sin(" << value << ") = " << calc(value, pTrigFunctions[0]) << endl;
  cout << " cos(" << value << ") = " << calc(value, pTrigFunctions[1]) << endl;
  cout << " tan(" << value << ") = " << calc(value, pTrigFunctions[2]) << endl;

  return 0;
}

double calc(const double& value, double (*pTrigFun)(double)) {
  return pTrigFun(value);  
}