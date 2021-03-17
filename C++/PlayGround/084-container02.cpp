#include <iostream>
#include <iterator>  // ostream_iterator()
#include <vector>    // For the vector container
#include <algorithm> // For the copy() function
using std::cout;
using std::endl;
using std::vector;

//使用vector容器

// Display a sequence of elements
void show_sequence(vector<int>::const_iterator first, vector<int>::const_iterator last)
{
    cout << "{ ";
    std::copy(first, last, std::ostream_iterator<int>(cout, " "));
    cout << "}" << endl;
}

// Display the contents of a vector
void inspect_vector(const vector<int> &v)
{
    cout << "  vector has " << v.size() << " elements: ";
    show_sequence(v.begin(), v.end());
}

int main()
{
    vector<int> v; // Create empty vector
    cout << "new vector created" << endl;
    inspect_vector(v);

    cout << "filling vector from array" << endl;
    int values[] = {1, 3, 7, 5};
    v.insert(v.end(), values + 1, values + 3); // Insert two elements
    inspect_vector(v);

    cout << "appending value 5" << endl;
    v.push_back(5); // Add an element at the end
    inspect_vector(v);

    cout << "erasing element at offset 1" << endl;
    //v.erase(&v[1]); // Remove the second element
    v.erase(v.begin() + 1); // Remove the second element
    inspect_vector(v);

    cout << "inserting element 4 at offset 1" << endl;
    v.insert(v.begin() + 1, 4); // Insert an element
    inspect_vector(v);

    cout << "clearing all elements" << endl;
    v.clear(); // Delete all elements
    inspect_vector(v);

    return 0;
}