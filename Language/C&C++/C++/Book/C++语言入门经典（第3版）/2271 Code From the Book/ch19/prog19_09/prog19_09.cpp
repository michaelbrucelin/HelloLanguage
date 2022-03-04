// Program 19.9 Writing a stack to a stream  File: prog19_09.cpp
#include <fstream>
#include <iostream>
#include <string>
#include "Stacks.h"
#include "Box.h"
using std::cout;
using std::endl;
using std::string;

int main() {
  Box Boxes[10];                            // 10 default boxes

  for(int i = 0 ; i < 10 ; i++)             // Create different objects
    Boxes[i] = Box(10*(i + 1), 10*(i + 2), 10*(i + 3));

  Stack<Box> boxStack;                      // A stack for Box objects

  // Push all Box objects onto the stack
  for(int i = 0 ; i < 10 ; i++)
    boxStack.push(Boxes[i]);

  const string boxFileName = "C:\\JunkData\\boxes.txt"; // Stack file
  std::ofstream outBoxFile(boxFileName.c_str()); // Output file stream for file

  outBoxFile << boxStack;                   // Write the stack
  outBoxFile.close();                       // Close the stream

  // Display volumes for original set
  while(!boxStack.isEmpty())
    cout << endl << "Volume = " << boxStack.pop().volume();

  Stack<Box> copyBoxStack;                  // New stack for Box objects

  std::ifstream inBoxFile(boxFileName.c_str()); // Open input file stream
  inBoxFile >> copyBoxStack;                // Read the stack

  // Output volumes of Box objects off the stack from the stream
  int i = 0;
  while(!copyBoxStack.isEmpty())
    cout << endl << "Volume of Box[" << (i++) << "] is "
         << copyBoxStack.pop().volume();

  cout << endl;
  return 0;
}
