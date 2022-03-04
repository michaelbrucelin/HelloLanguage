// Program 6.5 Storing strings in an array
#include <iostream>
using std::cout;
using std::cin;
using std::endl;

int main() {
  char stars[][80] = {
                       "Robert Redford",
                       "Hopalong Cassidy",
                       "Lassie",
                       "Slim Pickens",
                       "Boris Karloff",
                       "Mae West",
                       "Oliver Hardy",
                       "Sharon Stone"
                     };
  int choice = 0;

  cout << endl
       << "Pick a lucky star!"
       << " Enter a number between 1 and "
       << sizeof stars/sizeof stars[0] << ": ";
  cin >> choice;

  if(choice >= 1 && choice <= sizeof stars/sizeof stars[0])
    cout << endl
         << "Your lucky star is " << stars[choice - 1];
  else
    cout << endl                             // Invalid input
         << "Sorry, you haven't got a lucky star.";

  cout << endl;
  return 0;
}