// Exercise 20.2 Using a vector to store strings and sorting them
#include <vector>
#include <algorithm>
#include <string>
#include <iostream>
#include <cctype>
using  std::cout;
using  std::cin;
using  std::endl;
using  std::vector;
using  std::string;

int main() {
  vector<string> cities;                         // Stores the cities
  string city;                                   // Stores a city
  char ch = 'Y';
  for(int i = 0 ; std::toupper(ch)=='Y' ; i++) {
    cout << "\nEnter a city: ";
    std::getline(cin, city);
    cout <<"\ncity = " << city;
    cities.push_back(city);
    cout << "\nAnother? (Y or N):";
    cin >> ch;
    cin.ignore();                                // ignore the Enter in the input buffer
  }
  // Sort cities in ascending sequence
  std::sort(cities.begin(), cities.end());

  // List cities on cout on separate lines
  std::copy(cities.begin(), cities.end(), std::ostream_iterator<string>(cout, "\n"));
  cout << endl;
  return 0;
}