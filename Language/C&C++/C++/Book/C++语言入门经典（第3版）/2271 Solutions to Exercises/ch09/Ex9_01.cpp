// Exercise 9.1 Overloaded function plus(). 
/*****************************************************************************
The statement d = plus(3, 4.2); fails because the function call is ambiguous.
The compiler can't be sure whether you intended to use the int or double 
version of the overloaded function plus(). 
******************************************************************************/
#include <iostream>
#include<string>
using std::cout;
using std::endl;
using std::string;

int plus(const int& var1, const int& var2);
double plus(const double& var1, const double& var2);
string plus(const string& var1, const string& var2);

int main() {
  int n = plus(3, 4);
  double d = plus(3.2, 4.2);
  string s = plus("he", "llo");
  string s1 = "aaa"; string s2 = "bbb";
  string s3 = plus(s1, s2);
  
  cout << n << endl
       << d << endl
       << s << endl
       << s3 << endl;

//  d = plus(3, 4.2);    // Uncomment for an error

  return 0;
}

int plus(const int& var1, const int& var2) {
  return var1 + var2;
}

double plus(const double& var1, const double& var2) {
  return var1 + var2;
}

string plus(const string& var1, const string& var2) {
  return var1 + var2;
}