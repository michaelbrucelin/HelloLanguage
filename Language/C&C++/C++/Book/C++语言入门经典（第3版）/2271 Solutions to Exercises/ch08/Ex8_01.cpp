// Exercise 8.1 Reading  and validating a date of birth. 
#include <iostream> 
#include <string> 
using std::cout;
using std::cin;
using std::endl;
using std::string;

int valid_input(int lower, int upper, const string& description);
int year();
int month();
int date(int month_value, int year_value); 

int main() {
  cout << "Enter your date of birth." << endl;
  int date_year = year();
  int date_month = month();
  int date_day = date(date_month, date_year);

  string months[] = {"January", "February", "March",     "April",   "May",      "June",
                     "July",    "August",   "September", "October", "November", "December"
  };

  string ending = "th";
  if(date_day == 1 || date_day == 21 || date_day == 31)
    ending = "st";
  else if(date_day ==2  || date_day == 22)
    ending = "nd";
  else if(date_day == 3 || date_day == 23)
    ending = "rd";

  cout << endl
       << "We have established that your were born on " 
       << months[date_month-1] << " " << date_day << ending 
       << ", " << date_year << "." << endl;

  return 0;
}

// Reads an integer that is between lower and upper inclusive
int valid_input(int lower, int upper, const string& description) {
  int data = 0;   
  cout << "Please enter " << description 
       << " from " << lower << " to " << upper << ": ";
  cin >> data;
  while(data<lower || data>upper) {
    cout << "Invalid entry; please re-enter " << description << ": ";
    cin >> data;
  }  
  return data;
}


// Reads the year
int year() {
  const int low_year = 1850;  // Can't believe a user is over 150 
  const int high_year = 2000;   // or under 3 years old...
  return valid_input(low_year, high_year, "a year");
}

// Reads the month
int month() {
  const int low_month = 1;
  const int high_month = 12;
  return valid_input(low_month, high_month, "a month number");
}

// Reads in the date in the given month and year
int date(int month_number, int year) {
  const int date_min = 1;
  const int feb = 2;

 // Days in month:               Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec
  static const int date_max[] = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
  // With the above array declared as static, it will only be created the first
  // time the function is called. Of course, this doesn't save anything in this 
  // example as we only call it once...

  // Feb has 29 days in a leap year. A leap year is a year that is divible by 4
  // except years that are divisible by 100 but not divisible by 400
  if( month_number == feb && year%4 == 0 && !(year % 100 == 0 && year%400 != 0))
    return valid_input(date_min, date_max[month_number-1]+1, "a date");
  else
    return valid_input(date_min, date_max[month_number-1], "a date");
}