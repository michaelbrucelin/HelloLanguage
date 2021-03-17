#include <iostream>

using namespace std;

int main(void)
{
    int width = 4;
    char str[32];

    cout << "please input a string:\n";
    cin.width(5);

    while (cin >> str)
    {
        cout.width(width++);
        cout << str << endl;
        cin.width(5);
    }

    return (0);
}