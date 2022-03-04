// Program 7.3 Initializing pointers with strings
#include <iostream>
using std::cout;
using std::cin;
using std::endl;

int main() {
  // The lucky stars referenced through pointers
  const char* pstar1 = "Mae West";
  const char* pstar2 = "Arnold Schwarzenegger";
  const char* pstar3 = "Lassie";
  const char* pstar4 = "Slim Pickens";
  const char* pstar5 = "Greta Garbo";
  const char* pstar6 = "Oliver Hardy";
  const char* pstr   = "Your lucky star is ";

  int choice = 0;                       // Star selector

  cout << endl
       << "Pick a lucky star!"
       << " Enter a number between 1 and 6: ";
  cin >> choice;

  cout << endl;

  switch(choice) {
    case 1:
      cout << pstr << pstar1;
      break;
    case 2:
      cout << pstr << pstar2;
      break;
    case 3:
      cout << pstr << pstar3;
      break;
    case 4:
      cout << pstr << pstar4;
      break;
    case 5:
      cout << pstr << pstar5;
      break;
    case 6:
      cout << pstr << pstar6;
      break;
    default:
      cout << "Sorry, you haven't got a lucky star.";
  }

  cout << endl;
  return 0;
}
