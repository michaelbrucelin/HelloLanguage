// Exercise 14.4 MyString.cpp
// Definitions for member of the MyString class

#include "MyString.h"
#include <cstdlib>
#include <iostream>
using std::cout;
using std::endl;

namespace mySpace {

  // Default constructor
  MyString::MyString() {
    strLength = 0;               // Length excludes terminating null - this is empty string
    pStr = new char[1];          // Allocate space for string in the free store
    *pStr = '\0';                // Store terminating null
  }

  // Construct from a C-style string
  MyString::MyString(const char* pString) {
    strLength = strlen(pString);  // strlen() returns length excluding terinating null
    pStr = new char[strLength+1]; // Space must allow for null, hence strLength+1
    strcpy(pStr, pString);        // Copy argument string to data member
  }

  // Construct from repeated character
  MyString::MyString(char ch, int n) {
    strLength = n;
    pStr = new char[strLength+1];
    for(unsigned int i = 0 ; i<strLength ; *(pStr+i++) = ch) // 3rd expression stores ch then increments i
      ;                                             // No loop statement...
    *(pStr+strLength) = '\0';     // Store terminating null
  }

  // Construct string representation of integer
  MyString::MyString(int number) {
    char buffer[20];                    // Buffer to store string representation
    int temp = number;
    if(number<0)                        // If it is negative, 
      number = -number;                 // reverse the sign

    // Convert digits to characters in reverse order 
    int len = 0;
    do {
      buffer[len++] = static_cast<char>('0' + number%10);
      number /= 10;
    }while(number>0);
    if(temp<0)                          // If it was negative
      buffer[len++] = '-';              // Append a minus sign
    buffer[len] = '\0';                 // Apeend terminal \0

    strLength = len;                    // Store length of string

    pStr = new char[strLength+1];       // Allocate space
    std::strcpy(pStr, buffer);          // Copy string to data member
    // String is reversed so reverse it in place
    char ch = 0;
    for(int i = 0, j = len-1 ; i<j ; i++, j--) {
      ch = pStr[i];
      pStr[i] = pStr[j];
      pStr[j] = ch;
    }
  }

  // Copy constructor
  // Needs to allocate space for a copy of the string, then copy it
  MyString::MyString(const MyString& rString) {
    strLength = rString.strLength; // Store the length
    pStr = new char[strLength+1];  // Allocate the required space
    strcpy(pStr, rString.pStr);    // Copy the string
  }

  // Destructor
  // releases free store memory allocated to store string
  MyString::~MyString() {
    delete[] pStr;                 // Must use array form of delete here
  }

  // Find the position of a character
  // Compares succesive characters in the satring with the argument
  int MyString::find(char ch) const   {
    for(unsigned int i = 0 ; i<strLength ; i++)
      if(ch == *(pStr+i))           // If we find the character,
        return i;                   // return its position,
    return -1;                      // otherwise return -1
  }

  // Find the position of a string
  // Searches for the first character of the substring
  // and looks for the remaining characters if it is found
  int MyString::find(const char* pString) const {
    bool found = false;             // Sub-string found indicator

    // Search for the sub-string. We only need to look for
    // the first character up to the position where there is
    // enough room left for the sub-string to appear.
    for(unsigned int i = 0 ; i<strLength-strlen(pString)+1 ; i++)
      if(*(pStr+i) == *pString) {                 // If we find the first character
        found = true;
        for(unsigned int j = 1 ; j<strlen(pString) ; j++)  // look for the rest of the sub-string
          if(*(pStr+i+j) != *(pString+j)) {       // If any character doesn't match,
            found = false;                        // we didn't find it 
            break;                                // so go to next iteration in outer loop
          }
          if(found)                               // If we found it,
            return i;                             // Return the position,
      }
      return -1;                                  // otherwise return -1
  }

  // Find the occurrence of a MyString as a sub-string
  int MyString::find(const MyString& rString) const {
    return find(rString.pStr);                    // Just use the previous function to do it
  }

  // Display the string
  void MyString::show() const {
    if(strLength)
      cout << endl << pStr;
    else
      cout << endl << "String is empty.";
  }

  // Overloaded assignment operator
  MyString& MyString::operator=(const MyString& rhs) {
    if(this == &rhs)                      // Is lhs same object as rhs?
      return *this;                       // Yes, so just return it.

    // Objects are different so assign rhs to *this
    delete[] pStr;                        // Release memory for current string for *this object
    pStr = new char[rhs.strLength+1];     // Allocate space for string to be copied
    std::strcpy(pStr,rhs.pStr);           // Copy rhs string to lhs
    strLength = rhs.strLength;            // Set the length
    return *this;
  }

  // String concatenation
  // Operator must return a new object which is created as a local object 
  // A copy of the local object will be returned
  MyString MyString::operator+(const MyString& rhs) const {
    return MyString(*this) += rhs;
  }

  // Append MyString string
  // Operator returns a reference to the lhs
  // Uses the += operator for C-style strings to append the rhs string
  MyString& MyString::operator+=(const MyString& rhs) {
    return *this += rhs.pStr;  
  }

  // Append C-style string
  MyString& MyString::operator+=(const char* rhs) {
    char* pNewStr = new char[strLength+strlen(rhs)+1];   // Space for combined string
    std::strcpy(pNewStr,pStr);                           // Copy lhs string to new string
    std::strcpy(pNewStr+strLength,rhs);                  // Append rhs string to new string
    strLength += std::strlen(rhs);                       // Update length
    delete[] pStr;                                       // Release lhs string memory
    pStr = pNewStr;                                      // lhs string is new string
    return *this;                                        // Return lhs
  }

  // Subscript operator for const objects
  // Cannot be used on the left of an assignment as it return a const reference to char
  const char& MyString::operator[](int index) const {
    // These validity check would be better using exceptions to signal errors
    // rather than calling exit(). See Chapter 17
    if(strLength == 0) {
      cout << "\nString is empty in subscript operation. Program aborted.";
        exit(1);
    }
    if(strLength<index || index<0) {
      cout << "\nOut of range index in subscript operation. Program aborted.";
        exit(1);
    }

    if(index < strLength)
      return pStr[index];
  }

  // Subscript operator for non-const objects - can be used on the left of an assignment
  char& MyString::operator[](int index) {
    // These validity check would be better using exceptions to signal errors
    // rather than calling exit(). See Chapter 17
    if(strLength == 0) {
      cout << "\nString is empty in subscript operation. Program aborted.";
        exit(1);
    }
    if(strLength<index || index<0) {
      cout << "\nOut of range index in subscript operation. Program aborted.";
        exit(1);
    }

    if(index < strLength)
      return pStr[index];
  }

    // Overloaded 'equals' operator
  bool MyString::operator==(const MyString& rOperand) const {
    return (std::strcmp(pStr, rOperand.pStr) == 0);
  }

  // Overloaded 'not equals' operator
  bool MyString::operator !=(const MyString& rOperand) const {
    return (*this == rOperand);  
  }

  // Overloaded 'greater than' operator
  bool MyString::operator>(const MyString& rOperand) const {
    return (std::strcmp(pStr, rOperand.pStr) > 0);
  }

  // Overloaded 'less than' operator
  bool MyString::operator<(const MyString& rOperand) const {
    return (std::strcmp(pStr, rOperand.pStr) < 0);
  }

}   // End of namespace mySpace;