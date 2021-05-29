#include <iostream>
#include <iterator>
#include <algorithm>
#include <list>
using std::cout;
using std::endl;
using std::front_inserter;
using std::ostream_iterator;

//使用插入器

// Front insert
template <typename Container, class Iter>
void pre_insert(Container &C, Iter src, Iter src_end)
{
    std::copy(src, src_end, front_inserter(C));
}

int main()
{
    int values[] = {1, 9, 7, 5, 15};
    std::list<int> numbers; // Create a list container of integers

    // Append elements of values array to the front of the numbers list
    pre_insert(numbers, values, values + sizeof values / sizeof values[0]);

    // Copy the list to the output stream
    std::copy(numbers.begin(), numbers.end(), ostream_iterator<int>(cout, " "));
    cout << endl;

    return 0;
}