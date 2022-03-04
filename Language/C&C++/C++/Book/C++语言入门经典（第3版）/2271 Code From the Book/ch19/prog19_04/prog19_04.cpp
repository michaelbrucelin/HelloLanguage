// Program 19.4 Copying files  File: prog19_04.cpp
#include <iostream>                         // For standard streams
#include <cctype>                           // For character functions
#include <fstream>                          // For file streams
#include <string>                           // For strings
#include <stdexcept>                        // For standard exceptions
using std::cout;
using std::cin;
using std::endl;
using std::string;
using std::ios;
using std::invalid_argument;

int main(int argc, char* argv[]) {
  try {
    // Verify correct number of arguments
    if(argc != 3)
      throw invalid_argument("Input and output file names required.");

    const string source = argv[1];
    const string target = argv[2];

    // Check for output file identical to input file
    if(source == target)
      throw invalid_argument(string("Cannot copy ") +
                             string(source) +
                             string(" to itself."));

    std::ifstream in(source.c_str(), ios::in | ios::binary); 
    if(!in)                                 // Stream object OK?
      throw ios::failure(string("Input file ") +
                         string(source) +
                         string(" not found"));

    // Check if output file exists
    std::ifstream temp(target.c_str(), ios::in|ios::binary); 
    char ch = 0;                            // Stores a character
    if(temp) { // If the file stream object is ok then the output file exists
      temp.close();                         // Close the stream
      cout << endl << target << " exists, do you want to overwrite it? (y or n): ";
      ch = cin.get();
      if(std::toupper(ch) != 'Y')
        return 0;
    }

    // Create output file stream
    std::ofstream out(target.c_str(), ios::out|ios::binary|ios::trunc);

    // Copy the file
    while(in.get(ch))
      out.put(ch);

    if(in.eof())
      cout << endl << source << " copied to " << target << " successfully.";
    else
      cout << endl << "Error copying file";
    return 0;
  }
  catch(std::exception& ex) {
    cout << endl << typeid(ex).name() << ": " << ex.what();
    return 1;
  }
}
