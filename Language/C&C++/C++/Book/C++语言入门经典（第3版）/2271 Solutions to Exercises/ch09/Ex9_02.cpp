// Exercise 9.2 Creating a template for the plus() function. 
/******************************************************************************
In the third call, the arguments "he", "llo" are of type char[3] and char[4] 
respectively, and so they don't match the template definition. The solution in
this case is to cast the two string literals to type string before calling
the template instance[IN1]. 
******************************************************************************/
#include <iostream>
#include <string>
using std::cout;
using std::endl;
using std::string;

template<class T> T plus(const T& var1, const T& var2);

int main() {
  int n = plus(3, 4);
  double d = plus(3.2, 4.2);
  string s = plus(static_cast<string>("he"), static_cast<string>("llo"));
  string s1 = "aaa"; string s2 = "bbb";
  string s3 = plus(s1, s2);
  
  cout << n << endl
       << d << endl
       << s << endl
       << s3 << endl;

  return 0;
}

template<class T> T plus(const T& var1, const T& var2) {
  return var1 + var2;
}