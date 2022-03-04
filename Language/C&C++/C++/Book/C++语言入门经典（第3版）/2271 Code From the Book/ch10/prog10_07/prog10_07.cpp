// Program 10.7 Demonstrating assertions    File: prog10_07.cpp
#include <iostream>
#include <cassert>
using std::cout;
using std::endl;

int main() {
  int x = 0;
  int y = 5;

  cout << endl;
  
  for(x = 0 ; x < 20 ; x++) {
    cout << "x = " << x << "   y = " << y << endl;
    assert(x<y);
  }
  return 0;
}
