#include <iostream>
#include <iterator>
#include <string>
#include <sstream> // For the istringstream class
using std::cout;
using std::endl;
using std::istream_iterator;
using std::istringstream;
using std::string;

//istream_iterator<>的更多功能

template <typename Iter>
double average(Iter begin, Iter end)
{
    double sum = 0.0;
    int count = 0;
    for (; begin != end; ++count)
        sum += *begin++;

    return sum / (count == 0 ? 1 : count);
}

int main()
{
    // char* stock_ticker = "4.5 6.75 8.25 7.5 5.75";
    std::string stock_ticker = "4.5 6.75 8.25 7.5 5.75";
    istringstream ticker(stock_ticker);
    istream_iterator<double> begin(ticker);
    istream_iterator<double> end;

    cout << "Readings: " << stock_ticker << endl
         << "Today's average is "
         << average(begin, end) << endl;

    return 0;
}