// Exercise 17.4 SparseArray.h
// SparseArray class definition - stores pointers to strings

#ifndef SPARSEARRAY_H
#define SPARSEARRAY_H
#include <string>
using std::string;

class SparseArray {
  public:
    SparseArray(int n): maxElements(n), pFirst(0), pLast(0){}  // Constructor
    SparseArray(const SparseArray& array);                     // Copy constructor
    ~SparseArray();                                            // Destructor
    SparseArray& operator=(const SparseArray& array);          // Assignment operator
    string& operator[](int index);                             // Subscript SparseArray
    void show();                                               // display array elements

  private:
    // Node class definition
    class Node {
      public:
        int index;                       // Index of element
        string* pStr;                    // Address of element string
        Node* pNext;                     // Pointer to next node
        Node* pPrevious;                 // Pointer to previous node

        Node(int newIndex): 
               index(newIndex), pStr(new string), pNext(0), pPrevious(0){} // Constructor
        Node(const Node& node): 
               index(node.index), pStr(new string(*node.pStr)), pNext(0), pPrevious(0){}
                                                               // Copy constructor
        ~Node(){ delete pStr; }                                // Destructor
    };

    Node* pFirst;                        // Pointer to first element node
    Node* pLast;                         // Pointer to last element node
    int maxElements;
};
#endif //SPARSEARRAY_H