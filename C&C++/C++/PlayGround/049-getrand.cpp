#include <iostream>
#include <cstdlib>
#include <ctime>
using std::cout;
using std::endl;
using std::rand;
using std::srand;
using std::time;

int main(void)
{
    const int limit1 = 500; // Upper limit for on set of random values
    const int limit2 = 31;  // Upper limit for another set of values

    cout << "First we will use the default sequence from rand().\n";
    cout << "Three random integer from 0 to " << RAND_MAX << ": "
         << rand() << " " << rand() << " " << rand() << endl;

    cout << endl
         << "Now we will use a new seed for rand().\n";
    srand(static_cast<unsigned int>(time(0))); // Set a new seed

    cout << "Three random integer from 0 to " << RAND_MAX << ": "
         << rand() << " " << rand() << " " << rand() << endl;

    return (0);
}