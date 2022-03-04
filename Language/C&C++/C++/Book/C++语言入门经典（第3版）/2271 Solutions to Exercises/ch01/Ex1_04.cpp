// Exercise 1.4 If the using directive is missing from the code, the program will not compile. 
// The cout statement will produce an error. The problem could be rectified by altering the program code to:

#include <iostream>
int main() {
  std::cout << std::endl
            << "Hello World"
            << std::endl;

  return 0;
)

/*
This specifies the namespace for the standard library that the missing line allowed you to omit.
Alternatively you could just add the following using directives:

using std::cout;
using std::endl;

Either solution is better than the original because the original will introduce all the names from the iostream header into the source file. 
*/