// MyTroubles.cpp
#include "MyTroubles.h"

// Constructor for Trouble
Trouble::Trouble(const char* pStr) : pMessage(pStr) {}

// Destructor for Trouble
Trouble::~Trouble() {}

// Returns the message
const char* Trouble::what() const {
  return pMessage;
}  

// Constructor for MoreTrouble
MoreTrouble::MoreTrouble(const char* pStr) : Trouble(pStr) {}

// Constructor for BigTrouble
BigTrouble::BigTrouble(const char* pStr) : MoreTrouble(pStr) {}
