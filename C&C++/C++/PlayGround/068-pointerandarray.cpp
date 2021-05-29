#include <iostream>
#include <iomanip>
#include <cctype>
using std::cout;
using std::endl;
using std::setw;

int main()
{
    const int table = 12;            // Table size
    long values[table][table] = {0}; // Stores the table values

    // Calculate the table entries
    for (int i = 0; i < table; i++)
        for (int j = 0; j < table; j++)
            *(*(values + i) + j) = (i + 1) * (j + 1); // Full use of pointer notation

    // Create the top line of the table
    cout << "     |";
    for (int i = 1; i <= table; i++)
        cout << " " << setw(3) << i << " |";
    cout << endl;

    // Create the separator row
    for (int i = 0; i <= table; i++)
        cout << "------";
    cout << endl;

    for (int i = 0; i < table; i++)
    {                                            // Iterate over the rows
        cout << " " << setw(3) << i + 1 << " |"; // Start the row

        // Output the values in a row
        for (int j = 0; j < table; j++)
            cout << " " << setw(3) << values[i][j] << " |"; // Array notation
        cout << endl;                                       // End the row
    }

    return 0;
}