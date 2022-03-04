// Exercise 17.2 Throwing and catching CurveBalls and throwing TooManyExceptions
#include "CurveBall.h"
#include <cstdlib>
#include <ctime>
#include <iostream>
using std::cout;
using std::endl;

// Function to generate a random integer 0 to count-1
int random(int count) {
  return static_cast<int>((count*static_cast<long>(rand()))/(RAND_MAX+1L));
}

// Throw a CurveBall exception 25% of the time
// Note: Some compilers do not support exception specifications for functions
// If yours does not you may need to remove the exception specifications from 
// sometimes() and the what() member of CurveBall.
void sometimes() throw(CurveBall) {
  CurveBall e;
  if(random(20)<5)
    throw e;
}

// This program will terminate abnormally when the TooManyExceptions exception is thrown.
int main() {
  std::srand((unsigned)std::time(0));// Seed random number generator
  int number = 1000;                 // Number of loop iterations
  int exceptionCount = 0;            // Count of exceptions thrown
  TooManyExceptions eTooMany;        // Exception object

  for(int i = 0 ; i<number ; i++)
  try   {
    sometimes();
  }
  catch(CurveBall& e)   {
    cout << endl << e.what();
    if(++exceptionCount>10)
      throw eTooMany;
  }

  return 0;
}