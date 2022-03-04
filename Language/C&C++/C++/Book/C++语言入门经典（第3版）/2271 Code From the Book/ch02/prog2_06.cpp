// Program 2.6 Sizing a pond for happy fish
#include <iostream>             
#include <cmath>                      // For square root calculation
using std::cout;
using std::cin;
using std::sqrt;

int main() {
  const double fish_factor = 2.0/0.5; // Area per unit length of fish
  const double inches_per_foot = 12.0;
  const double pi = 3.14159265;

  double fish_count = 0.0;           // Number of fish
  double fish_length = 0.0;          // Average length of fish 

  cout << "Enter the number of fish you want to keep: ";
  cin >> fish_count;
  cout << "Enter the average fish length in inches: ";
  cin >> fish_length;
  fish_length = fish_length/inches_per_foot; // Convert to feet

  // Calculate the required surface area
  double pond_area = fish_count * fish_length * fish_factor;

  // Calculate the pond diameter from the area
  double pond_diameter = 2.0 * sqrt(pond_area/pi);

  cout << "\nPond diameter required for " << fish_count << " fish is "
       << pond_diameter << " feet.\n";
  return 0;
}
