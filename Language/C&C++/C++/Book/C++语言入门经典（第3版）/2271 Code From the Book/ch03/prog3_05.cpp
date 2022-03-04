// Program 3.5 – Exercising an enumeration
#include <iostream>
using std::cout;

int main() {
  enum Language { English, French, German, Italian, Spanish };

  // Display range of enumerators
  cout << "\nPossible languages are:\n"
       << English << ". English\n"
       << French  << ". French\n"
       << German  << ". German\n"
       << Italian << ". Italian\n"
       << Spanish << ". Spanish\n";

  Language tongue = German;
  cout << "\n Current language is " << tongue;

  tongue = static_cast<Language>(tongue + 1);
  cout << "\n Current language is now " << tongue
       << std::endl;
  return 0;
}
