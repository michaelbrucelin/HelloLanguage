// Stacks.h Templates to define stacks
#ifndef STACKS_H
#define STACKS_H
#include <stdexcept>

template<typename T> class Stack;     // Class template declaration 

// Prototypes for friend templates
template<typename T> std::istream& operator >> (std::istream& in, Stack<T>& rStack);
template<typename T> std::ostream& operator << (std::ostream& out, const Stack<T>& rStack);

template <typename T> class Stack {
  public:
    Stack():pHead(0){}                                 // Default constructor
    Stack(const Stack& aStack);                        // Copy constructor
    ~Stack();                                          // Destructor
    Stack& operator=(const Stack& aStack);             // Assignment operator

    void push(T& rItem);                               // Push an object onto the stack
    T pop();                                           // Pop an object off the stack
    bool isEmpty() {return pHead == 0;}                // Empty test

    friend std::ostream& operator<< <T>(std::ostream& out, const Stack& rStack);
    friend std::istream& operator>> <T>(std::istream& in, Stack& rStack);

  private:
    class Node {
      public:
        T* pItem;                                      // Pointer to object stored
        Node* pNext;                                   // Pointer to next node

        Node(T* pNew) : pItem(pNew), pNext(0) {}       // Construct a node from an object
        Node() : pItem(0), pNext(0) {}                 // Construct an empty node
        ~Node() {delete pItem;}
    };

    Node* pHead;                                       // Points to the top of the stack
    void copy(const Stack& aStack);                    // Helper to copy a stack
    void freeMemory();                                 // Helper to release free store memory

    // Write Node objects to a stream
    std::ostream& writeNodes(std::ostream& out, Node* pNode) const;  
    Node* readNodes(std::istream& in);                  // Read Node objects from stream
};

// Copy constructor
template <typename T> Stack<T>::Stack(const Stack& aStack) {
  copy(aStack);
}

// Helper to copy a stack
template <typename T> void Stack<T>::copy(const Stack& aStack) {
  pHead = 0;
  if(aStack.pHead) {
    pHead = new Node(*aStack.pHead);              // Copy the top node of the original
    Node* pOldNode = aStack.pHead;                // Points to the top node of the original
    Node* pNewNode = pHead;                       // Points to the node in the new stack

    while(pOldNode = pOldNode->pNext) {           // If it is null, it is the last node
      pNewNode->pNext = new Node(*pOldNode);      // Duplicate it
      pNewNode = pNewNode->pNext;                 // Move to the node just created
    }
  }
}

// Assignment operator
template <typename T> Stack<T>& Stack<T>::operator=(const Stack& aStack) {
  if(this == &aStack)                            // If objects are identical
    return *this;                                // return the left object
  
  freeMemory();                                  // Release memory for nodes in lhs
  copy(aStack);                                  // Copy rhs to lhs

  return *this                                   // Return the left object
}

// Helper to release memory for a stack
template <typename T> void Stack<T>::freeMemory() {
  Node* pTemp;
  while(pHead) {                                 // While current pointer is not null
    pTemp = pHead->pNext;                        // Get the pointer to the next
    delete pHead;                                // Delete the current
    pHead = pTemp;                               // Make the next current
  }
}

// Destructor
template <typename T> Stack<T>::~Stack() {
  freeMemory();
}

// Push an object onto the stack
template <typename T> void Stack<T>::push(T& rItem) {
  Node* pNode = new Node(new T(rItem));        // Create node from object copy
  pNode->pNext = pHead;                        // Point to the old top node
  pHead = pNode;                               // Make the new node the top
}

// Pop an object off the stack
template <typename T> T Stack<T>::pop() {
  if(!pHead)                                    // If it is empty
    throw std::logic_error("Stack empty");      // Pop is not valid so throw exception

  T item(*pHead->pItem);                        // Local copy of top object
  Node* pTemp = pHead;                          // Save address of top node
  pHead = pHead->pNext;                         // Make next node the top
  delete pTemp;                                 // Delete the previous top node
  return item;                                  // Return copy of top object
}

// Friend Insertion operator function
template <typename T> 
std::ostream& operator<<(std::ostream& out, const Stack<T>& rStack) {
  out << ' ' << (rStack.pHead != 0);
  return rStack.writeNodes(out, rStack.pHead);
}

// Friend Extraction operator function
template <typename T> 
std::istream& operator>>(std::istream& in, Stack<T>& rStack) {
  bool notEmpty;
  in >> notEmpty;
  if(notEmpty)
    rStack.pHead = rStack.readNodes(in);
  else
    rStack.pHead = 0;
  return in;
}

template <typename T> 
std::ostream& Stack<T>::writeNodes(std::ostream& out, Node* pNode) const {
  while(pNode) {
    out << ' ' << *(pNode->pItem);
    out << ' ' << (pNode->pNext != 0);
    pNode = pNode->pNext;
  }
  return out;
}


template <typename T> 
typename Stack<T>::Node* Stack<T>::readNodes(std::istream& in) {
  Node* pNode = new Node;                  // Create a Node object
  pNode->pItem = new T;                    // Create the T object and store its address
  in >> *pNode->pItem;                     // Read the T object from the stream

  bool isNext;
  in >> isNext;
  if(isNext)
    pNode->pNext = readNodes(in);
  else pNode->pNext = 0;
  return pNode;
}

#endif
