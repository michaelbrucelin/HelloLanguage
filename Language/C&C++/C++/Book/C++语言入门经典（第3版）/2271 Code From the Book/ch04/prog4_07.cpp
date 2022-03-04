// Program 4.7 Using the conditional operator to select output.
#include <iostream>
using std::cin;
using std::cout;
using std::endl;

int main() {
  int mice = 0;              // Count of all mice
  int brown = 0;             // Count of brown mice
  int white = 0;             // Count of white mice

  cout << "How many brown mice do you have? ";
  cin >> brown;

  cout << "How many white mice do you have? ";
  cin >> white;

  mice = brown + white;

  cout << "You have "
       << mice
       << (mice == 1 ? " mouse " : " mice ")
       << "in total."
       << endl;
  return 0;
}
