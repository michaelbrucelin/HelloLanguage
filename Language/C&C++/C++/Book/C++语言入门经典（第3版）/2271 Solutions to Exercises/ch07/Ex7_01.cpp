// Exercise 7.1 Using pointer notation to access the elements of an array.
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

int main()
{
  const int elements = 50;
  int evens[elements];
  for(int i = 0 ; i < elements ; i++)
    evens[i] = 2*(i+1);

  cout << endl << "The elements in the array are:" << endl;
  for(int i = 0 ; i < elements ; i++) {
    if(i%10 == 0)
      cout << endl;
    cout << std::setw(4) << *(evens+i);
  }
  cout << endl;

  cout << endl << "In reverse order the elements are:" << endl;
  for(int i = elements ; i > 0  ; i--) {
    if(i%10 == 0)
      cout << endl;
    cout << std::setw(4) << *(evens+i-1);
  }
  cout << endl;


  return 0;
}