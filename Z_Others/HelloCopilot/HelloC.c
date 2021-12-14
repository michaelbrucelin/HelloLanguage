#include <stdio.h>

// function returns the day of the week the specified date falls on
int dayOfWeek(int month, int day, int year)
{
    int a = (14 - month) / 12;
    int y = year - a;
    int m = month + 12 * a - 2;
    int d = (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
    return d;
}

// function returns the number of days in the specified month
int daysInMonth(int month, int year)
{
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
    {
        return 31;
    }
    else if (month == 4 || month == 6 || month == 9 || month == 11)
    {
        return 30;
    }
    else if (month == 2)
    {
        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
        {
            return 29;
        }
        else
        {
            return 28;
        }
    }
    else
    {
        return 0;
    }
}

// function returns the number of days in the specified year
int daysInYear(int year)
{
    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
    {
        return 366;
    }
    else
    {
        return 365;
    }
}

// fucntion returns the number of days between the specified dates
int daysBetween(int month1, int day1, int year1, int month2, int day2, int year2)
{
    int days = 0;
    int i;
    for (i = year1; i < year2; i++)
    {
        days += daysInYear(i);
    }
    for (i = month1; i < month2; i++)
    {
        days += daysInMonth(i, year1);
    }
    days += day1;
    days -= day2;
    return days;
}

// example of a function that returns string values
char *dayOfWeekString(int day)
{
    switch (day)
    {
    case 0:
        return "Sunday";
    case 1:
        return "Monday";
    case 2:
        return "Tuesday";
    case 3:
        return "Wednesday";
    case 4:
        return "Thursday";
    case 5:
        return "Friday";
    case 6:
        return "Saturday";
    default:
        return "Invalid day";
    }
}