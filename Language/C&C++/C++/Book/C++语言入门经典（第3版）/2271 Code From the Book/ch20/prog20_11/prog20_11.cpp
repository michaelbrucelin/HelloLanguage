// Program 20.11 A TruckLoad container implemented using an STL list container
// Recapitulates Program 13.1
#include <iostream>
#include <algorithm>
#include "TruckLoad.h"
using std::cout;
using std::endl;

// Random number generation 1 to count
inline int random(int count) {
  return 1 + static_cast<int>(count*static_cast<double>(rand())/(RAND_MAX+1.0));
}

// Create a Box with random dimensions in a range
inline Box random_box(int range) {
  return Box(random(range),random(range),random(range));
} 

int main() {
  TruckLoad rig1(Box(30,30,30));
  for(int i = 0; i < 8; ++i) 
    rig1.add_box(random_box(100));

  cout << "Contents of rig1" << endl;
  std::copy(rig1.begin(), rig1.end(), std::ostream_iterator<Box> (cout, "\n"));
  cout << endl;

  typedef TruckLoad::const_iterator BoxIter;
  BoxIter big_one = max_element(rig1.begin(), rig1.end());

  cout << "The biggest box in rig1 is " << *big_one 
       << " with volume " << big_one->volume() << endl;
  cout << endl;

  cout << "Copying all boxes starting at big box to rig2" << endl;
  TruckLoad rig2(big_one, rig1.end());
  cout << "Contents of rig2" << endl;
  std::copy(rig2.begin(), rig2.end(), std::ostream_iterator<Box> (cout, "\n"));
  cout << endl;

  return 0;
}
