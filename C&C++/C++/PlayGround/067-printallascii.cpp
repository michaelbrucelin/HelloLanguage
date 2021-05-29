#include <iostream>
#include <iomanip>
#include <cctype>
#include <limits>
using std::cout;
using std::endl;
using std::setw;

int main()
{
    // Output the column headings
    cout << endl
         << setw(13) << "Character  "
         << setw(13) << "Hexadecimal "
         << setw(13) << "Decimal   "
         << endl;

    cout << std::uppercase; // Uppercase hex digits

    unsigned char ch = 0; // Character code

    // Output characters and corresponding codes
    do
    {
        if (!std::isprint(ch)) // If it does not print
            continue;          // skip this iteration

        cout << setw(7) << ch
             << std::hex // Hexadecimal mode
             << setw(13) << static_cast<int>(ch)
             << std::dec // Decimal mode
             << setw(13) << static_cast<int>(ch)
             << endl;
    } while (ch++ < std::numeric_limits<unsigned char>::max());

    return 0;
}