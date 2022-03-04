// Exercise 9.4 Computing Ackerman's function. 

#include <iostream> 
#include <iomanip> 
using std::cout;
using std::cin;
using std::endl;

// Using unsigned long provides the maximum possible range of values
// but is woefully inadequate for significant values of m and n.
unsigned long ack(const unsigned long& m, const unsigned long& n);

int main() {
  int m = 0;
  int n = 0;
  cout << "Computing values of Ackerman's function:" << endl;
  cout << "Enter the upper limit for m: ";
  cin >> m;
    cout << "Enter the upper limit for n: ";
  cin >> n;
  if (m>3 && n>0 || m>2 && n>8)
    cout << "You are an optimist!" << endl;

  // Create array dynamically to hold values
  long** ack_values = new long*[m+1];  // Pointer to array of arrays of type long elements
  for(int i = 0 ; i<=m ; i++)
    ack_values[i] = new long[n+1];

  // Store values in the array
  for(int i=0; i<=m; i++) 
    for(int j=0; j<=n; j++) 
      ack_values[i][j] = ack(i,j);
    
  for(int i=0; i<=m; i++) {
    cout << endl;
    for(int j=0; j<=n; j++) 
      cout << std::setw(12) << ack_values[i][j];
  }
  cout << endl;

  for(int i = 0 ; i<m+1 ; i++)
    delete[] ack_values[i];
  delete ack_values;

return 0;
}

unsigned long ack(const unsigned long& m, const unsigned long& n) {
  if(m==0)
    return n+1;
  if(n==0) 
    return ack(m-1, 1);
  return ack(m-1, ack(m, n-1));
}