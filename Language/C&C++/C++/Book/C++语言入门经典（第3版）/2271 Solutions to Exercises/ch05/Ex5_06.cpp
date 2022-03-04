// Exercise 5.6 Generate a lottery entry consisting of 6 numbers from 1 to 49
#include <iostream>
#include <iomanip>
#include <cmath>
#include <ctime>
using std::cout;
using std::endl;
using std::setw;

int main() {
  const int selections = 6;                            // Number of selections in an entry
  const int n_max = 49;                                // Maximum value of a selection
  int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0, n6 = 0;  // Selections in an entry
  int possible = 0;                                    // Selection candidate

  std::srand(static_cast<unsigned int>(std::time(NULL)));

  for (int i = 1 ; i<= selections ; i++)
    while(true) {
      possible = static_cast<int>(std::ceil(static_cast<double>(n_max*std::rand())/RAND_MAX));
      possible = possible == 0 ? 1 : possible;  // Make sure it's at least 1
    switch(i) {
      case 1:
        n1 = possible;
        break;
      case 2:
        if(possible == n1)
          continue;
        n2 = possible;
        break;
      case 3:
        if(possible == n1 || possible == n2)
          continue;
        n3 = possible;
        break;
      case 4:
        if(possible == n1 || possible == n2 || possible == n3)
          continue;
        n4 = possible;
        break;
      case 5:
        if(possible == n1 || possible == n2 || possible == n3 || possible == n4)
          continue;
        n5 = possible;
        break;
      case 6:
        if(possible == n1 || possible == n2 || possible == n3 || possible == n4 || possible == n5)
          continue;
        n6 = possible;
        break;
    }
    break;
  }
    cout << "Your lottery entry for this week is :" << endl
         << setw(4) << n1 << setw(4) << n2 << setw(4) << n3 
         << setw(4) << n4 << setw(4) << n5 << setw(4) << n6 << endl;
  return 0;
}