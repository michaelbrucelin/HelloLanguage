// Exercise 19.3 Writing Time class 0bjects to a file.

#include "Time.h"
#include <cctype>
#include <iostream>
#include <fstream>
#include <string>

using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  string fileName;
  cout << "\nEnter the name of the file you want to write, including the path: ";
  std::getline(cin, fileName);
  std::ofstream outFile(fileName.c_str());
  if(!outFile) {
    cout << "\nFailed to open output file. Program terminated.";
    exit(1);
  }

  Time period;
  char ch = 'n';

  do {
    cout << "\nEnter a time as hours:minutes:seconds, and press Enter: ";
    cin >> period;
    outFile << period;
    cout << "\n Do you want to enter another?(y or n): ";
    cin >> ch;
  }while(std::toupper(ch)=='Y');

  outFile.close();

  cout << endl;
  return 0;
}