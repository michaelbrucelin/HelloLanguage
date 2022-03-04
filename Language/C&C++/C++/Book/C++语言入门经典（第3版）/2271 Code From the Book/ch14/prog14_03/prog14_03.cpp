// Program 14.3 Overloading the copy assignment operator  File: prog14_03.cpp
#include <iostream>
#include <cstring>
using std::cout;
using std::endl;

#include "ErrorMessage.h"

int main() {
  ErrorMessage warning("There is a serious problem here");
  ErrorMessage standard;

  cout << endl << "warning contains - " << warning.what();
  cout << endl << "standard contains - " << standard.what();

  standard = warning;                               // Use assignment operator

  cout << endl << "After assigning the value of warning, standard contains - " 
       << endl << standard.what();

  cout << endl << "Resetting warning, not standard" << endl;
  warning.resetMessage();                           // Reset the Warning message

  cout << endl << "warning now contains - " << warning.what();
  cout << endl << "standard now contains - " << standard.what();
  cout << endl;

  return 0;
}
