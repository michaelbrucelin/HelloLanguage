#include <iostream>
#include <iomanip>
#include <string>

using std::cout;
using std::endl;
using std::string;

// 在使用有多个默认值参数时，需要注意参数的顺序
// 最不需要的参数放在最后，前面的参数需要明确指定值的可能性逐个递增，通常情况下这是个很好的规则

void show_data(const int data[], int count = 1,
               const string &title = "Data Values", int width = 10, int perLine = 5);

int main()
{
    int samples[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

    int dataItem = 99;
    show_data(&dataItem);

    dataItem = 13;
    show_data(&dataItem, 1, "Unlucky for some!");

    show_data(samples, sizeof samples / sizeof samples[0]);
    show_data(samples, sizeof samples / sizeof samples[0], "Samples");
    show_data(samples, sizeof samples / sizeof samples[0], "Samples", 14);
    show_data(samples, sizeof samples / sizeof samples[0], "Samples", 14, 4);

    return 0;
}

void show_data(const int data[], int count, const string &title, int width, int perLine)
{
    cout << endl
         << title; // Display the title

    // Output the data values
    for (int i = 0; i < count; i++)
    {
        if (i % perLine == 0) // Newline before the first
            cout << endl;     // and after perLine

        cout << std::setw(width) << data[i]; // Display a data item
    }
    cout << endl;
}