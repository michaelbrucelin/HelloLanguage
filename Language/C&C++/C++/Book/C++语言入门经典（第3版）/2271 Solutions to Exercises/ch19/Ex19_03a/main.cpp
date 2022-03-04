// Exercise 19.3a Reading Time class 0bjects from a file.

#include "Time.h"
#include <iostream>
#include <fstream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string fileName;
  cout << "\nEnter the name of the file you want to read, including the path: ";
  std::getline(cin, fileName);
  std::ifstream inFile(fileName.c_str());
  if(!inFile) {
    cout << "\nFailed to open input file. Program terminated.";
    exit(1);
  }

  Time period;
  int count = 0;
  cout << "\nTimes on file are: ";

  while(!(inFile >> period).eof()) {
    if(count++ % 5 == 0)
      cout << endl;              // Newline every 5th output
    cout << period;
  }

  inFile.close();

  cout << endl;
  return 0;
}