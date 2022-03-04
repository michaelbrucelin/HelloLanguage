// Exercise 20.3 Using a map to store names and phone numbers.
#include <map>
#include <algorithm>
#include <string>
#include <iostream>
using std::cout;
using std::cin;
using std::endl;
using std::string;

// Name is used as the key and is stored as a pair surname,firstname
// Number is stored as a string to allow embedded spaces.
// Note that this will not allow duplicate names as keys
typedef std::map<std::pair<string, string> , string> directory;

int main() {
  directory phoneBook;
  char surname[50];
  char firstname[50];
  string number;
  cout << "\nEnter surname, first name, and phone number, "
       << "\nseparated by spaces. The number can have "
       << "\nembedded spaces. Enter ! to end:\n";
  for(;;) {
    cin >> surname;
    if('!' == surname[0])
      break;
    cin >> firstname;
    getline(cin, number);

    // The key is the surname and firstname encapsulated in a pair
    // The object is the phone number
    phoneBook[std::make_pair(string(surname),string(firstname))] = number;
  }

  directory::iterator pNumber;
  cout << "\nTo obtain phone numbers from the directory, please "
       << "\nenter surname and first name - separated by spaces."
       << "\nEnter ! to end:\n";
  for(;;) {
    cin >> surname;
    if('!' == surname[0])
      break;
    cin >> firstname;
    pNumber = phoneBook.find(std::make_pair(string(surname),string(firstname)));
    if(pNumber == phoneBook.end())
      cout << "\nEntry not found.\n";
    else
      cout << "\nNumber is " << pNumber->second << endl;
  }
  cout << "\nDone.\n";
  return 0;
}