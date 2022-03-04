// Exercise 19.1 Time.h
// Definition of Time class

#ifndef TIME_H
#define TIME_H
#include <iostream>

class Time {
  public:
    Time(): hours(0),minutes(0), seconds(0){}          // Default constructor 
    Time(int h, int m, int s);                         // Constructor
    int getHours()const { return hours; }
    int getMinutes()const { return minutes; }
    int getSeconds()const { return seconds; }

  private:
    int hours;
    int minutes;
    int seconds;
};

std::ostream& operator <<(std::ostream& out, const Time& rT); // Overloaded operator declaration

#endif //TIME_H