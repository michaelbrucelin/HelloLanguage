// Program 19.1 Writing primes to a file  File: prog19_01.cpp
#include <fstream>                                // For file streams
#include <iomanip>

int main() {
  const int max = 100;                            // Number of primes required
  long primes[max] = {2, 3, 5};                   // First three primes defined
  int count = 3;                                  // Count of primes found
  long trial = 5;                                 // Candidate prime
  bool isprime = true;                            // Indicates when a prime is found

  do {
    trial += 2;                                   // Next value for checking
    int i = 0;                                    // Index to primes array

    // Try dividing the candidate by all the primes we have
    do {
      isprime = trial % *(primes + i) > 0;        // False for exact division
    } while(++i < count && isprime);

    if(isprime)                                   // We got one...
      *(primes + count++) = trial;                // ...so save it in primes array
  } while(count < max);

  std::ofstream outFile("c:\\JunkData\\primes.txt");   // Define file stream object

  // Output primes 5 to a line
  for(int i = 0 ; i < max ; i++) {
    if(i % 5 == 0)                                // New line after every 5th prime
      outFile << std::endl;
    outFile << std::setw(10) << *(primes + i);
  }

  return 0;
}
