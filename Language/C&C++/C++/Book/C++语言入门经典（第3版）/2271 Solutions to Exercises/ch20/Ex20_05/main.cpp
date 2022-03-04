// Exercise 20.5 Updating Ex20.4 to use a multimap
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
typedef std::pair<string, string> name_pair;   // The object type in the mutimap
typedef std::multimap<name_pair , string> directory;

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
    // With a multimap we must use the insert() function to add an element
    phoneBook.insert(std::make_pair(name_pair(string(surname),string(firstname)), number));
  }

  directory::iterator pNumber;
  directory::iterator pNumberEnd;
  name_pair aName;
  cout << "\nTo obtain phone numbers from the directory, please "
       << "\nenter surname and first name - separated by spaces."
       << "\nEnter ! to end:\n";
  for(;;) {
    cin >> surname;
    if('!' == surname[0])
      break;
    cin >> firstname;
    aName = std::make_pair(string(surname),string(firstname));
    pNumber = phoneBook.find(aName);
    pNumberEnd = phoneBook.upper_bound(aName);
    if(pNumber == phoneBook.end())
      cout << "\nEntry not found.\n";
    else { 
      while(pNumber != pNumberEnd)
        cout << "\nNumber is " << (pNumber++)->second;
      cout << endl;
    }
  }

  // List the directory contents
  cout << "\nPhone book listing is:\n";
  for(pNumber = phoneBook.begin() ; pNumber != phoneBook.end() ; pNumber++)
    cout << endl 
         << pNumber->first.first << ' '<< pNumber->first.second << ' ' << pNumber->second;
  cout << "\nDone.\n";

  return 0;
}