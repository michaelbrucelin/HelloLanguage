// Exercise 19.4b Converting contents of a stream to upper case.
#include <iostream>
#include <fstream>
#include <cctype>
#include <cstring>
using std::cout;
using std::cin;
using std::endl;

// Program to convert contents of a stream to upper case
// We must treat the standard input streams as a special case.
// Because cin has no end of file, so we must determine end of input differently.

// Function to copy one stream to another converting to upper case
void copy(std::istream& in, std::ostream& out, char end = ' ') {
  char ch;

  while(in.get(ch))      
  {
    if(end != ' ' && end == ch) // Check for end on cin
      break;
    out.put(std::toupper(ch));
  }
}


// Requires two command line arguments identifying the input and output streams
// First argument is cin or the name and path of the input file
// Second argument is cout or the name and path of the output file
int main(int argc, char* argv[]) {
  if(argc<3) {
    cout << "\nThis program requires two command line arguments."
         << "\nThe first command line argument is the input file name and path, or cin."
         << "\nThe second is the output file name and path, or cout.";
    exit(1);
  }

  cout << "\nReading from " << argv[1] << " and writing to " << argv[2] << endl;

  bool kbd = std::strcmp(argv[1], "cin") == 0;           // Standard input stream indicator
  bool scrn = std::strcmp(argv[2], "cout") == 0;         // Standard output stream indicator
  char end;                                         // Indicates end of input on cin;
  if(kbd) {
    cout << "\nEnter the character you want to indicate end of input: ";
    cin >> end;
    if(scrn)
      copy(cin, cout, end);
    else {
      std::ofstream outFile(argv[2]);
      if(!outFile) {
        cout << "\nFailed to open output file. Program terminated.";
        exit(1);
      }
      copy(cin, outFile, end);
    }
  }
  else {
    std::ifstream inFile(argv[1]);
    if(!inFile) {
      cout << "\nFailed to open input file. Program terminated.";
      exit(1);
    }
    if(scrn)
      copy(inFile, cout);
    else
    {
      std::ofstream outFile(argv[2]);
      if(!outFile) {
        cout << "\nFailed to open output file. Program terminated.";
        exit(1);
      }
      copy(inFile, outFile);
    }
  }
  cout << "\n Stream copy complete.";
  cout << endl;
  return 0;
}