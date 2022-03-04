// Exercise 6.2 Storing, displaying and averaging a series of humidity readings, using a two-dimensional array.

#include <iostream>
#include <string>
using std::cout;
using std::cin;
using std::endl;
using std::string;

int main() {
  const string days[] = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
  const string times[] = {"morning", "midday", "evening"};

  float humidity[sizeof days/sizeof days[0]][sizeof times/sizeof times[0]] = {0.0f};
  float day_averages[sizeof days/sizeof days[0]] = {0.0f};
  float week_averages[sizeof times/sizeof times[0]] = {0.0f};

  // Loops used for entering humidity data and accumulating totals.
  for(int day = 0 ; day < sizeof days/sizeof days[0] ; day++) {
    cout << endl << days[day] << endl;
    for(int time = 0 ; time < sizeof times/sizeof times[0] ; time++) {
      cout << "  Enter " << times[time] << " reading: ";
      cin  >> humidity[day][time];
      week_averages[time] += humidity[day][time];     // Accumulate total for current time
      day_averages[day] += humidity[day][time];       // Accumulate total for current day
    }
  }
  cout << endl;

  // Output average for each day
  for(int day = 0 ; day < sizeof days/sizeof days[0] ; day++)
    cout << "Average humidity for " << days[day]  << ": " 
         << day_averages[day]/(sizeof times/sizeof times[0]) << endl;

  cout << endl;

  // Output weekly average for each time
  for(int time = 0 ; time < sizeof times/sizeof times[0] ; time++)
    cout << "Average " << times[time]  << " humidity: " 
         << week_averages[time]/(sizeof days/sizeof days[0]) << endl;


  return 0;
}