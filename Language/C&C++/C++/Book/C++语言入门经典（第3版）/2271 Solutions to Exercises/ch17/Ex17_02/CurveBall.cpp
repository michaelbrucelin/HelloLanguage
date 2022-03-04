// Exercise 17.2 CurveBall.cpp
// Implementation of CurveBall and TooManyExceptions exception classes

#include "CurveBall.h"

const char* CurveBall::what() const throw() {
  return "CurveBall exception";
}

const char* TooManyExceptions::what() const throw() {
  return "TooManyExceptions exception";
}