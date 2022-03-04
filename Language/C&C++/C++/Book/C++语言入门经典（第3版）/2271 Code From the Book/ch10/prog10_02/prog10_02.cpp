// Program 10.2 Using a namespace   File: prog10_02.cpp
#include <iostream>
#include <string>

namespace data {
  extern const double pi;        // Variable is defined in another file
  extern const std::string days[];  // Array is defined in another file
}

int main() {
  std::cout << std::endl
            << "pi has the value " 
            << data::pi << std::endl;

  std::cout << "The second day of the week is " 
            << data::days[1] << std::endl;

  return 0;
}
