#include <iostream>
#include <string>

using std::cin;
using std::cout;
using std::endl;
using std::string;

// Function prototypes
void swap(string *pStr[], int first, int second);
void sort(string *pStr[], int start, int end);
int count_words(const string &text, const string &separators);
void extract_words(string *pStr[], const string &text, const string &separators);
void show_words(string *pStr[], int count);

int main()
{
    string text;                         // The string to be sorted
    const string separators = " ,.\"\n"; // Word delimiters

    // Read the string to be searched from the keyboard
    cout << endl
         << "Enter a string terminated by #:" << endl;
    getline(cin, text, '#');

    int word_count = count_words(text, separators); // Get count of words

    if (0 == word_count)
    {
        cout << endl
             << "No words in text." << endl;
        return 0;
    }

    string **pWords = new string *[word_count]; // Array of pntrs to words

    extract_words(pWords, text, separators);
    sort(pWords, 0, word_count - 1); // Sort the words
    show_words(pWords, word_count);  // Output the words

    // Delete words from free store
    for (int i = 0; i < word_count; i++)
        delete pWords[i];

    // Now delete the array of pointers
    delete[] pWords;

    return 0;
}

// Swap address at position first with address at position second
void swap(string *pStr[], int first, int second)
{
    string *temp = pStr[first];
    pStr[first] = pStr[second];
    pStr[second] = temp;
}

// Sort strings in ascending sequence
// Addresses of words to be sorted are from pStr[start] to pStr[end]
void sort(string *pStr[], int start, int end)
{
    // start index must be less than end index for 2 or more elements
    if (!(start < end))
        return; // Less than 2 elements – nothing to do

    // Choose middle address to partition set
    swap(pStr, start, (start + end) / 2); // Swap middle address with start

    // Check words against chosen word
    int current = start;
    for (int i = start + 1; i <= end; i++)
        if (*(pStr[i]) < *(pStr[start])) // Is word less than chosen word?
            swap(pStr, ++current, i);    // Yes, so swap to the left

    swap(pStr, start, current); // Swap the chosen word with last in

    sort(pStr, start, current - 1); // Partition the left set
    sort(pStr, current + 1, end);   // Partition the right set
}

// Function to count the words in the text
int count_words(const string &text, const string &separators)
{
    size_t start = text.find_first_not_of(separators); // Word start index
    size_t end = 0;                                    // End delimiter index
    int word_count = 0;                                // Count of words stored
    while (start != string::npos)
    {
        end = text.find_first_of(separators, start + 1);
        if (end == string::npos) // Found one?
            end = text.length(); // No, so set to last+1
        word_count++;            // Increment count

        // Find the first character of the next word
        start = text.find_first_not_of(separators, end + 1);
    }
    return word_count;
}

// Function to extract words from the text
void extract_words(string *pStr[], const string &text, const string &separators)
{
    size_t start = text.find_first_not_of(separators); // Start 1st word
    size_t end = 0;                                    // Index for the end of a word
    int index = 0;                                     // Pointer array index

    while (start != string::npos)
    {
        end = text.find_first_of(separators, start + 1); // Find end separator
        if (end == string::npos)                         // Found one?
            end = text.length();                         // No, so set to last+1
        pStr[index++] = new string(text.substr(start, end - start));
        start = text.find_first_not_of(separators, end + 1); // Find next word
    }
}

// Function to output the words
void show_words(string *pStr[], int count)
{
    const int words_per_line = 5; // Word_per_line
    cout << endl
         << "  " << *pStr[0]; // Output the first word

    int words_in_line = 0; // Words in the current line
    for (int i = 1; i < count; i++)
    { // Output remaining words
        // Newline when initial letter changes or after 5 wrds per line
        if ((*pStr[i])[0] != (*pStr[i - 1])[0] ||
            words_in_line++ == words_per_line)
        {
            words_in_line = 0;
            cout << endl;
        }
        cout << "  " << *pStr[i]; // Output a word
    }
    cout << endl;
}