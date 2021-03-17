#include <fstream>
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

// 读取文件

int main()
{
    const char *filename = "/tmp/primes.txt";
    std::ifstream inFile(filename);

    if (!inFile)
    {
        cout << endl
             << "Failed to open file " << filename;
        return 1;
    }

    long aprime = 0;
    int count = 0;
    while (!inFile.eof())
    {
        inFile >> aprime;
        cout << (count++ % 5 == 0 ? "\n" : "") << std::setw(10) << aprime;
    }
    cout << endl;

    return 0;
}