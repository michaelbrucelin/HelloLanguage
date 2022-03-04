// Program 20.13 An inverted word collocation  File: prog20_13.cpp
#include <iostream>
#include <iomanip>
#include <string>
#include <sstream>
#include <map>
using std::cout;
using std::endl;
using std::string;
const string twister = 
  "How much wood would a woodchuck chuck if a woodchuck " 
  "could chuck wood?  A woodchuck would chuck as much wood " 
  "as a woodchuck could chuck if a woodchuck could chuck wood.";

int main() {
  typedef std::map<string, int> Collocation;    // Type for our map
  typedef Collocation::const_iterator WordIter; // Iterator type for our map
  
  Collocation words;           // Map to store words and word counts

  std::istringstream text(twister);             // Text string as a stream
  std::istream_iterator<string> begin(text);    // Stream iterator 
  std::istream_iterator<string> end;            // End stream iterator

  for( ; begin != end ; ++begin)       // Iterate over the words in the stream 
    words[*begin]++;                   // Store and increment word count

  typedef std::multimap<int,string, std::greater<int> > WordRank; 
  typedef WordRank::const_iterator RankIter;

  WordRank rank;                        // Ranking the words by count

  for(WordIter iter = words.begin() ; iter != words.end() ; ++iter) 
    rank.insert(std::make_pair(iter->second,iter->first));

  for(RankIter iter = rank.begin() ; iter != rank.end() ; ++iter) 
    cout << std::setw(6) << iter->first << " " << iter->second << endl;

  return 0;
}
