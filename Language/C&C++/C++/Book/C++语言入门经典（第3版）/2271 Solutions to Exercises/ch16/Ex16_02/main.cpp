// Exercise 16.2  Creating length objects
// Note that, because you're using typeid with derived classes, you may need to
//  ensure that you have enabled the Run-Time Type Information option in your compiler.
// For more information on run-time type checking, see your compiler's documentation. 

#include "Lengths.h"
#include <iostream>
#include <string>
#include <typeinfo>
using std::string;
using std::cout;
using std::cin;
using std::endl;

// Read a length from the keyboard
BaseLength* readLength() {
  string units;                               // Stores the input string
  double value = 0.0;                         // Stores the length value

  for(;;)   {
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

  // Output the lengths - we must figure out what type they are to display the units
  for(int i = 0 ; i<nLengths ; i++) {
    string units(" invalid type");
    if(typeid(*pLengths[i])==typeid(Inches))
      units = " inches";
    else if(typeid(*pLengths[i])==typeid(Meters))
      units = " meters";
    else if(typeid(*pLengths[i])==typeid(Yards))
      units = " yards";
    else if(typeid(*pLengths[i])==typeid(Perches))
      units = " perches";
    cout << "\nLength is " << pLengths[i]->length() << units 
         << " which is "   << pLengths[i]->BaseLength::length() << " millimeters.";
  }

  cout << endl;

  // Release memory for lengths
  for(int i = 0 ; i<nLengths ; i++)
    delete pLengths[i];

  return 0;
}