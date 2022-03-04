// Program 19.6 Reading and writing the primes file as binary
#include <fstream>
#include <iostream>
#include <cmath>
#include <string>
using namespace std;

long nextprime(fstream& primes);                           // Find the prime after lastprime
void write(ostream& out, long value);                      // Write binary long value
void read(istream& in, long& value);                       // Read binary long value

int main()
{
  try
  {
    const char* filename = "C:\\JunkData\\nuprimes.bin";
    fstream primes;                                          // Create file stream object
    primes.open(filename, ios::in | ios::out | ios::binary); // Open the file
    long count = 0;                                          // Count of primes found

    if(!primes)
    {
      primes.clear();
      cout << endl << "File doesn't exist - creating..." << endl;
      primes.open(filename, ios::out | ios::binary);         // Create binary file

      if(!primes)
        throw ios::failure(string("Failed to create output file ") +
                           string(filename) +
                           string(" in main()"));
      write(primes, 2);                                      // Write 2 as binary long
      write(primes, 3);                                      // Write 3 as binary long
      write(primes, 5);                                      // Write 5 as binary long
      write(primes, count = 3);                              // Write prime count
      primes.close();
      primes.open(filename, ios::in | ios::out | ios::binary);
    }

    long nprime = 0;                                       // Sequence no. of prime required
    long lastprime = 0;                                    // Last prime found
    for( ; ; )
    {
      cout << "Which prime (e.g. enter 15 for the 15th prime, zero to end)?: ";
      cin >> nprime;
      if(nprime <= 0)                                      // Zero or negative?
        return 0;                                          //  ...yes, so we are done

      primes.seekg(-static_cast<int>(sizeof(long)), ios::end); // Go to start of last item
      read(primes, count);                                     // Read the last item

      if(nprime <= count)
      {
        cout << endl << "Prime in file";
        primes.seekg((nprime - 1) * sizeof(long), ios::beg); // Seek to position of nth
        read(primes, lastprime);                             //  ...and read it
      }
      else
        while(count < nprime)
        {
          lastprime = nextprime(primes);
          primes.seekp(-static_cast<int>(sizeof(long)), ios::end);  // Move to the end
          write(primes, lastprime);                          // Write prime as binary
          write(primes, ++count);                            // Write prime as binary
        }

      cout << endl   << "The "
           << nprime << ((nprime%10 == 1) && (nprime != 11) ? "st" :
                         (nprime%10 == 2) && (nprime != 12) ? "nd" :
                         (nprime%10 == 3) && (nprime != 13) ? "rd" : "th")
           << " prime is " << lastprime << endl;
    }
    cout << endl;
    return 0;

  }
  catch(exception& ex)
  {
    cout << endl << typeid(ex).name() << ": " << ex.what() << endl;
    return 1;
  }
}

long nextprime(fstream& primes)
{
  bool isprime = false;                                    // Indicator that we have a prime
  long aprime = 0;                                         // Stores primes from the file
  long candidate = 0;                                      // Value to be tested

  primes.seekg(-static_cast<int>(2 * sizeof(long)), ios::end);  // Go to last prime in file
  read(primes, candidate);                                 // ...and read it

  // Find the next prime
  for( ; ; )
  {
    candidate += 2;                                        // Next value for checking
    long limit = sqrt(candidate);                          // Upper limit for divisors
    primes.seekg(0, ios::beg);                             // Go to the start of the file

    // Try dividing the candidate by all the primes up to limit
    do
    {
      read(primes, aprime);                                // Read prime as binary
    } while(aprime <= limit && (isprime = candidate % aprime > 0));

    if(isprime)                                            // We got one...
      return candidate;                                    // ...and return the prime
  }
}

// Read a long value from a file as binary
void read(istream& in, long& value)
{
  in.read(reinterpret_cast<char*>(&value), sizeof(value));
}

// Write a long value to a file as binary
void write(ostream& out, long value)
{
  out.write(reinterpret_cast<char*>(&value), sizeof(value));
}
