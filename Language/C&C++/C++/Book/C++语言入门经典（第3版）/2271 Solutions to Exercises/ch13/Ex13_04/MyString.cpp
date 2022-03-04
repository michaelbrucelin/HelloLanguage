// Exercise 13.4 MyString.cpp
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

}   // End of namespace mySpace