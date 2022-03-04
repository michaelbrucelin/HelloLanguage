// Exercise 5.5 Selective output
#include <iostream>
#include <iomanip>

int main() {
  
  for (int i = 1 ; i<= 25 ; i++) {
      if(i>10 && i<20)
        continue;
    std::cout << std::setw(3) << i;
  }
  std::cout << std::endl;
  return 0;
}