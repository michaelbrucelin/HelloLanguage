#include <fstream>
#include <iostream>
#include <iomanip>
#include <cmath>
#include <string>
using std::cin;
using std::cout;
using std::endl;
using std::ios;
using std::string;

// 把二进制数值数据写入文件

long nextprime(long lastprime, const char *filename); // Find the prime after lastprime
void write(std::ostream &out, long value);            // Write binary long value
void read(std::istream &in, long &value);             // Read binary long value

int main()
{
    const char *filename = "C:\\JunkData\\primes.bin";
    int nprimes = 0;    // Number of primes required
    int count = 0;      // Count of primes found
    long lastprime = 0; // Last prime found

    // Get number of primes required
    int tries = 0; // Number of input tries
    cout << "How many primes would you like (at least 3)?: ";
    do
    {
        if (tries)
            cout << endl
                 << " You must request at least 3, try again: ";
        cin >> nprimes;

        if (++tries == 5)
        { // Five tries is generous
            cout << endl
                 << " I give up!" << endl;
            return 1;
        }
    } while (nprimes < 3);

    std::ifstream inFile;                         // Create input file stream object
    inFile.open(filename, ios::in | ios::binary); // Open the file as an input stream
    cout << endl;
    if (!inFile.fail())
    {
        do
        {
            inFile >> lastprime;
            cout << (count++ % 5 == 0 ? "\n" : "") << std::setw(10) << lastprime;
        } while (count < nprimes && !inFile.eof());
        inFile.close();
    }
    inFile.clear(); // Clear any errors

    try
    {
        std::ofstream outFile;
        if (count == 0)
        {
            // Open file to create it
            outFile.open(filename, ios::out | ios::binary | ios::app);
            if (!outFile.is_open())
                throw ios::failure(string("Error opening output file ") + string(filename) + string(" in main()"));
            write(outFile, 2L); // Write 2 as binary long
            write(outFile, 3L); // Write 3 as binary long
            write(outFile, 5L); // Write 5 as binary long
            outFile.close();
            cout << std::setw(10) << 2 << std::setw(10) << 3 << std::setw(10) << 5;
            lastprime = 5;
            count = 3;
        }

        while (count < nprimes)
        {
            lastprime = nextprime(lastprime, filename);
            // Open file to append data
            outFile.open(filename, ios::out | ios::binary | ios::app);
            if (!outFile.is_open())
                throw ios::failure(string("Error opening output file ") + string(filename) + string(" in main()"));
            write(outFile, lastprime); // Write prime as binary value
            outFile.close();
            cout << (count++ % 5 == 0 ? "\n" : "") << std::setw(10) << lastprime;
        }
        cout << endl;
        return 0;
    }
    catch (std::exception &ex)
    {
        cout << endl
             << typeid(ex).name() << ": " << ex.what();
        return 1;
    }
}

// Find the next prime after the argument
long nextprime(long lastprime, const char *filename)
{
    bool isprime = false; // Indicator that we have a prime
    long aprime = 0;      // Stores primes from the file
    std::ifstream inFile; // Local input stream object

    // Find the next prime
    for (;;)
    {
        lastprime += 2; // Next value for checking
        long limit = static_cast<long>(std::sqrt(static_cast<double>(lastprime)));

        // Try dividing the candidate by all the primes up to limit
        inFile.open(filename, ios::in | ios::binary); // Open the primes file
        if (!inFile.is_open())
            throw ios::failure(string("Error opening input file ") + string(filename) + string(" in nextprime()"));
        do
        {
            read(inFile, aprime); // Read prime as binary
        } while (aprime <= limit && !inFile.eof() && (isprime = lastprime % aprime > 0));

        inFile.close();
        if (isprime)          // We got one...
            return lastprime; // ...so return it
    }
}

// Read a long value from a file as binary
void read(std::istream &in, long &value)
{
    in.read(reinterpret_cast<char *>(&value), sizeof(value));
}

// Write a long value to a file as binary
void write(std::ostream &out, long value)
{
    out.write(reinterpret_cast<char *>(&value), sizeof(value));
}