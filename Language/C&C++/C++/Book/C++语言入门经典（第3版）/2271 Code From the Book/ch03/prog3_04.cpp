// Program 3.4 Using the bitwise operators
#include <iostream>
#include <iomanip>
using std::cout;
using std::endl;
using std::setfill;
using std::setw;

int main() {
  unsigned long red = 0XFF0000UL;      // Color red
  unsigned long white = 0XFFFFFFUL;    // Color white - RGB all maximum

  cout << std::hex;                    // Set hexadecimal output format
  cout << setfill('0');                // Set fill character for output

  cout << "\nTry out bitwise AND and OR operators.";
  cout << "\nInitial value  red         = " << setw(8) << red;
  cout << "\nComplement    ~red         = " << setw(8) << ~red;

  cout << "\nInitial value  white       = " << setw(8) << white;
  cout << "\nComplement    ~white       = " << setw(8) << ~white;

  cout << "\n Bitwise AND   red & white = " << setw(8) << (red & white);
  cout << "\n Bitwise OR    red | white = " << setw(8) << (red | white);

  cout << "\n\nNow we can try out successive exclusive OR operations.";

  unsigned long mask = red ^ white;

  cout << "\n        mask = red ^ white = " << setw(8) << mask;
  cout << "\n                mask ^ red = " << setw(8) << (mask ^ red);
  cout << "\n              mask ^ white = " << setw(8) << (mask ^ white);

  unsigned long flags = 0xFF;          // Flags variable
  unsigned long bit1mask = 0x1;        // Selects bit 1
  unsigned long bit6mask = 0x20;       // Selects bit 6
  unsigned long bit20mask = 0x80000;   // Selects bit 20

  cout << "\n\nNow use masks to select or set a particular flag bit.";
  cout << "\nSelect bit 1 from flags    : " << setw(8) << (flags & bit1mask);
  cout << "\nSelect bit 6 from flags    : " << setw(8) << (flags & bit6mask);
  cout << "\nSwitch off bit 6 in flags  : " << setw(8) << (flags &= ~bit6mask);
  cout << "\nSwitch on bit 20 in flags  : " << setw(8) << (flags |= bit20mask);
  cout << endl;

  return 0;
}
