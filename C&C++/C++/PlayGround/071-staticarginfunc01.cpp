#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

long next_Fibonacci();

int main()
{
    cout << endl
         << "The Fibonacci Series" << endl;
    for (int i = 0; i < 30; i++)
    {
        if (i % 5 == 0)   // Every fifth number...
            cout << endl; // ...start a new line
        cout << std::setw(12) << next_Fibonacci();
    }
    cout << endl;

    return 0;
}

// Function to generate the next number in the Fibonacci series
long next_Fibonacci()
{
    static long last = 0;         // Last number in sequence
    static long last_but_one = 1; // Last but one number

    long next = last + last_but_one; // Next is sum of the last two
    last_but_one = last;             // Update last but one
    last = next;                     // Last is new one

    return last; // Return the new one
}