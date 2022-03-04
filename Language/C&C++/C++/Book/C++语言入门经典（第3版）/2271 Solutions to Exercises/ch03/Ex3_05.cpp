//Exercise 3.5 Write a program to read four characters from the keyboard and pack them into a single
// 4-byte integer variable. Display the value of this variable as hexadecimal. 
// Unpack the four bytes of the variable and output them in reverse order - with  the
// low order byt first.
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  char ch1 = 0, ch2 = 0, ch3 = 0, ch4 = 0;
  cout << "Enter four characters: ";
  cin >> ch1 >> ch2 >> ch3 >> ch4;

  unsigned int packed = ch1;
  packed = (((((packed << 8) | ch2) << 8) | ch3) << 8) | ch4;
  cout << "Value of packed characters: " 
    << std::hex << std::showbase << packed << endl;

  unsigned int mask = 0xff;
  ch1 = packed & mask;
  ch2 = packed >> 8 & mask;
  ch3 = packed >> 16 & mask;
  ch4 = packed >> 24 & mask;
  cout << "Characters in reverse order are: "
       << ch1 << ch2 << ch3 << ch4 << endl;;
  return 0;

}