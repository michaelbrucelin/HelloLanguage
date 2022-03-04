// ErrorMessage.cpp ErrorMessage class implementation
#include <cstring>
#include "ErrorMessage.h"
using std::cout;
using std::endl;

// Constructor
ErrorMessage::ErrorMessage(const char* pText) {
  pMessage = new char[ strlen(pText) + 1 ];             // Get space for message
  std::strcpy(pMessage, pText);                         // Copy to new memory
}

// Destructor to free memory allocated by new
ErrorMessage::~ErrorMessage() {
  cout << endl << "Destructor called." << endl;
  delete[] pMessage;                                    // Free memory for message
}

// Change the message
void ErrorMessage::resetMessage() {
  // Replace message text with asterisks
  for(char* temp = pMessage ; *temp != '\0' ; *(temp++) = '*')
    ;
}

// Assignment operator
ErrorMessage& ErrorMessage::operator=(const ErrorMessage& message) {
  if(this == &message)                              // Compare addresses, if equal
    return *this;                                   // return left operand

  delete[] pMessage;                                // Release memory for left operand
  pMessage = new char[ strlen(message.pMessage) + 1];

  // Copy right operand string to left operand
  std::strcpy(this->pMessage, message.pMessage);

  return *this;                                     // Return left operand
}

