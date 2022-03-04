// Program 8.9 Using multiple default parameter values
#include <iostream>
#include <iomanip>
#include <string>
using std::cout;
using std::end;
using std::string;

// The function prototype including defaults for reference parameters
void show_data(const int data[], int count = 1,
            const string& title = "Data Values", int width = 10, int perLine = 5);

int main() {
  int samples[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

  int dataItem = 99;
  show_data (&dataItem);

  dataItem = 13;
  show_data(&dataItem, 1, "Unlucky for some!");

  show_data(samples, sizeof samples/sizeof samples[0]);
  show_data(samples, sizeof samples/sizeof samples[0], "Samples");
  show_data(samples, sizeof samples/sizeof samples[0], "Samples", 14);
  show_data(samples, sizeof samples/sizeof samples[0], "Samples", 14, 4);

  return 0;
}

// Function to output one or more integer values
void show_data (const int data[], int count, const string& title,
                                                         int width, int perLine) {
  cout << endl << title;                    // Display the title

  // Output the data values
  for(int i = 0 ; i < count ; i++) {
    if(i % perLine == 0)                    // Newline before the first
      cout << endl;                         // and after perLine

    cout << std::setw(width) << data[i];    // Display a data item
  }
  cout << endl;
}
