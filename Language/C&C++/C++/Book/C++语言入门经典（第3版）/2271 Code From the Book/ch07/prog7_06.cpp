// Program 7.6 Calculating primes
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

int main() {
  const int max = 100;                      // Number of primes required
  long primes[max] = {2, 3, 5};             // First three primes defined
  int count = 3;                            // Count of primes found
  long trial = 5;                           // Candidate prime
  bool isprime = true;                      // Indicates when a prime is found

  do {
    trial += 2;                             // Next value for checking
    int i = 0;                              // Index to primes array

    // Try dividing the candidate by all the primes we have
    do {
      isprime = trial % *(primes + i) > 0;  // False for exact division
    } while(++i < count && isprime);

    if(isprime)                             // We got one...
      *(primes + count++) = trial;          // ...so save it in primes array
  } while(count < max);

  // Output primes 5 to a line
  for(int i = 0 ; i < max ; i++) {
    if(i % 5 == 0)                          // Newline on 1st line and after every 5th prime
      cout << endl;
    cout << std::setw(10) << *(primes + i);
  }
  cout << endl;
  return 0;
}
