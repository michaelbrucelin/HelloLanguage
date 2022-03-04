// Exercise 5.4 Generating a random password
#include <iostream>
#include <cctype>
#include <limits>
#include <ctime>
using std::cout;
using std::cin;
using std::endl;
using std::numeric_limits;

int main() {
  const int chars_in_password= 8;
  char ch = 0;
  std::srand(static_cast<unsigned int>(std::time(NULL)));

  cout << "Your password is: ";

  // We have to read at least one character - even if it's '#' - so do-while is best
  for (int i = 0 ; i< chars_in_password ; i++)
    while(true) {
      // Character code is a random value between the minimum and maximum for type char
      ch = numeric_limits<char>::min()+((numeric_limits<char>::max()-numeric_limits<char>::min())*std::rand())/RAND_MAX;
      if(!std::isalnum(ch))
        continue;
      cout << ch;
      break;
    }
  cout << endl;
  return 0;
}