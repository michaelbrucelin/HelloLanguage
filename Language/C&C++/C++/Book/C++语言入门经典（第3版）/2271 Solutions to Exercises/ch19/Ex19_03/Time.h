// Exercise 19.3 Time.h
// Definition of Time class File

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

    friend std::istream& operator>> (std::istream& in, Time& rT);  // Friend extraction operator
  private:
    int hours;
    int minutes;
    int seconds;
};

std::ostream& operator <<(std::ostream& out, const Time& rT); // Overloaded operator declaration

#endif //TIME_H