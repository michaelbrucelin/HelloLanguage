// Exercise 17.2 CurveBall.h
// Definition of CurveBall and TooManyExceptions exception classes

#ifndef CURVEBALL_H
#define CURVEBALL_H
#include <exception>

class CurveBall: public std::exception {
  public:
    const char* what() const throw();
};

class TooManyExceptions: public std::exception {
  public:
    const char* what() const throw();
};

#endif //CURVEBALL_H