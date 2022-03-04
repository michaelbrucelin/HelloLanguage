// Exercise 7.4 Allocating arrays of arrays dynamically 
// The tricky part is that you have to delete the arrays in reverse order,
// so the code (with a bit of manipulation for good measure) looks like this:

#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;

int main() {
  const int arrays = 3;
  const int elements = 6;

  int** ppint;         // Pointer to array of arrays

  // Create an array to hold a pointer to each array
  ppint = new int*[arrays];    // Array of pointers

  // Create each array, and store its address in the array of pointers
  for (int i = 0 ; i < arrays ; i++)
    ppint[i] = new int[elements];   // Create array of integers and store its address

  // Initialize fuirst array to successive integers - array notation  
  for (int i = 0 ; i < elements ; i++)
      ppint[0][i] = i+1;

  // Initialize second array to squares of successive integers - mixed notation  
  for (int i = 0 ; i < elements ; i++)
      *(ppint[1]+i) = *(ppint[0]+i)**(ppint[0]+i);

  // Initialize third array to cubes of successive integers - pointer notation  
  for (int i = 0 ; i < elements ; i++)
      *(*(ppint+2)+i) = *(*ppint+i)**(*(ppint+1)+i); // Product of corresponding elements in first two arrays


  // Output values of all elements - array notation 
  for (int i = 0 ; i < arrays ; i++) {
    for (int j = 0 ; j < elements ; j++) 
      cout << std::setw(5) << ppint[i][j];
    cout << endl;
  }

  // Delete in reverse order
  for (int i = 0 ; i < arrays ; i++)
    delete [] ppint[i];

  delete [] ppint;
  return 0;
}