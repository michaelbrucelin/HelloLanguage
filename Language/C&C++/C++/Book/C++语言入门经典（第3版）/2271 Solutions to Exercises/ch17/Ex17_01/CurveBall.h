// Exercise 17.1 CurveBall.h
// Definition of CurveBall Exception class

#ifndef CURVEBALL_H
#define CURVEBALL_H
#include <exception>

class CurveBall: public std::exception {
  public:
    const char* what() const throw();
};
#endif //CURVEBALL_H