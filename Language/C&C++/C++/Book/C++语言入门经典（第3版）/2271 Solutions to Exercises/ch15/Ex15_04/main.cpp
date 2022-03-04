// Exercise 15.4 Working with Employee and Executive objects

#include "Person.h"
#include <iostream>
using std::cout;
using std::endl;

int main() {
  Employee employees[5];
  employees[0] = Employee(21, "Randy Marathon", 'm', 34567);
  employees[1] = Employee(32, "Anna Pothecary", 'f', 34578);
  employees[2] = Employee(46, "Peter Out", 'm', 34589);
  employees[3] = Employee(37, "Sheila Rangeit", 'f', 34598);
  employees[4] = Employee(65, "Jack Ittin", 'm', 34667);

  for(int i = 0 ; i<sizeof employees/sizeof(Employee) ; i++)
    employees[i].who();

  Executive executives[5];
  executives[0] = Executive(44, "Irwin Pootlemeyer", 'm', 35567);
  executives[1] = Executive(32, "Alexa Workwell", 'f', 35578);
  executives[2] = Executive(42, "Steve Stove", 'm', 35589);
  executives[3] = Executive(33, "Sue Neenuf", 'f', 35598);
  executives[4] = Executive(29, "Melanie Clair", 'f', 35667);

  for(int i = 0 ; i<sizeof executives/sizeof(Executive) ; i++) {
    executives[i].who();
    executives[i].Employee::who();
  }
  cout << endl;

  return 0;
}