// Exercise 8.3 Checking the number of arguments entered at the command line. 
#include <iostream>
using std::cout;
using std::endl;

int main(int argc, char* argv[]) {
  switch(argc-1) {
    case 2: case 3: case 4: 
      for(int i = 1; i < argc; i++)
      cout << "Argument " << i << " is " << argv[i] << endl;
      break;
    default: 
      cout << "You entered the incorrect number of arguments. " << endl
           << "Please enter 2, 3 or 4 arguments. " << endl;
  }
  return 0;
}