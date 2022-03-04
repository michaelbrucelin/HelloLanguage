// Program 7.4 Using an array of pointers to char
#include <iostream>
using std::cout;
using std::cin;
using std::endl;

int main() {
  const char* pstars[] = {
                           "Mae West",                      // Initializing a pointer array
                           "Arnold Schwarzenegger",
                           "Lassie",
                           "Slim Pickens",
                           "Greta Garbo",
                           "Oliver Hardy"
                         };
  const char* pstr = "Your lucky star is ";
  int choice = 0;

  const int starCount = sizeof pstars / sizeof pstars[0];   // Get array size

  cout << endl
       << "Pick a lucky star!"
       << " Enter a number between 1 and "
       << starCount
       << ": ";
  cin >> choice;

  cout << endl;
  if(choice >= 1 && choice <= starCount)                    // Check for valid input
    cout << pstr << pstars[choice - 1];                     // Output star name
  else
    cout << "Sorry, you haven't got a lucky star.";         // Invalid input

  cout << endl;
  return 0;
}
