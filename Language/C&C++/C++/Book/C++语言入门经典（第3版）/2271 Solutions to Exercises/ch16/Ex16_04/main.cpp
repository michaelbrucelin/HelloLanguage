// Exercise 16.4  Converting length objects using operators and constructors
#include "Lengths.h"
#include <iostream>
#include <string>
using std::string;
using std::cout;
using std::cin;
using std::endl;

// Read a length from the keyboard
BaseLength* readLength() {
  string units;                               // Stores the input string
  double value = 0.0;                         // Stores the length value

  for(;;) {
    cout << "\nEnter a length:";
    cin >> std::skipws >> value;              // Skip whitespace and read the value
    getline(cin, units);                      // Rest of line is units
    int index = units.find_first_not_of(" "); // Find first non-blank in units

    // Return the object type corresponding to the units
    switch(toupper(units[index])) {
      case 'M':
        return new Meters(value);
      case 'I':
        return new Inches(value);
      case 'Y':
        return new Yards(value);
      case 'P':
        return  new Perches(value);
      default:
      cout << "\nInvalid units. Re-enter length.";
      break;
    }
  }
}

int main() {
  const int nLengths = 5;
  BaseLength* pLengths[nLengths];
  cout << "\nYou can enter lengths in inches, meters, "
       << "\nyards, or perches. The first character "
       << "\nfollowing the number will determine the "
       << "\nunits, and can be i, m y or p."
       << "\ne.g. '22 ins' is 22 inches "
       << "\n'3.5 p' or '3.5perches' is 3.5 perches "
       << "\n'1y' is 1 yard."
       << endl
       << "\nPlease enter " << nLengths << " lengths now: "
       << endl;

  for(int i = 0 ; i<nLengths ; i++)
    pLengths[i] = readLength();
  
  // Output the lengths
  // These can only use the conversion operators, because the calls are resolved at compile
  // time to the base class functions( because a pLengths element is a base class pointer).
  for(int i = 0 ; i<nLengths ; i++)
    cout << "\nLength is " << static_cast<Inches>(*pLengths[i]).length()  << " inches, " 
                           << static_cast<Yards>(*pLengths[i]).length()   << " yards, "
                           << static_cast<Meters>(*pLengths[i]).length()  << " meters, "
                           << static_cast<Perches>(*pLengths[i]).length() << " perches, "
                           << pLengths[i]->BaseLength::length() << " millimeters.";

  cout << endl;

  // Release memory for lengths
  for(int i = 0 ; i<nLengths ; i++)
    delete pLengths[i];

  // Object to exercise constructors to do conversions
  Inches inLength(5);
  Yards ydLength(5);
  Meters mLength(5);
  Perches pchLength(5);

  // These use the class constructors to do conversions. You can verify this
  // by adding an output statement to each constructor.
  // However, if you comment out the conversion constructors for one of the classes,
  // it should still work using the inherited conversion operators instead.
  cout << "\nLength is " << inLength.length()                       << " inches, " 
                         << static_cast<Yards>(inLength).length()   << " yards, "
                         << static_cast<Meters>(inLength).length()  << " meters, "
                         << static_cast<Perches>(inLength).length() << " perches. ";

  cout << "\nLength is " << static_cast<Inches>(ydLength).length()  << " inches, " 
                         << ydLength.length()                       << " yards, "
                         << static_cast<Meters>(ydLength).length()  << " meters, "
                         << static_cast<Perches>(ydLength).length() << " perches, ";

  cout << "\nLength is " << static_cast<Inches>(mLength).length()   << " inches, " 
                         << static_cast<Yards>(mLength).length()    << " yards, "
                         << mLength.length()                        << " meters, "
                         << static_cast<Perches>(mLength).length()  << " perches. ";

  cout << "\nLength is " << static_cast<Inches>(pchLength).length() << " inches, " 
                         << static_cast<Yards>(pchLength).length()  << " yards, "
                         << static_cast<Meters>(pchLength).length() << " meters, "
                         << pchLength.length()                      << " perches. ";

  cout << endl;
  return 0;
}