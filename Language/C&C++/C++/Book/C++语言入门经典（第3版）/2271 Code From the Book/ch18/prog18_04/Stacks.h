// Stack.h Templates to define stacks
#ifndef STACKS_H
#define STACKS_H
#include <stdexcept>

template <typename T> class Stack {
  private:
    class Node {
      public:
        T* pItem;                            // Pointer to object stored
        Node* pNext;                        // Pointer to next node

        Node(T& rItem) : pItem(&rItem), pNext(0) {} // Create a node from an object
        Node() : pItem(0), pNext(0) {}      // Create an empty node
    };

    Node* pHead;                            // Points to the top of the stack
    void copy(const Stack& aStack);         // Helper to copy a stack
    void freeMemory();                      // Helper to release free store memory

  public:
    Stack():pHead(0){}                      // Default constructor
    Stack(const Stack& aStack);             // Copy constructor
    ~Stack();                               // Destructor
    Stack& operator=(const Stack& aStack);  // Assignment operator

    void push(T& rItem);                    // Push an object onto the stack
    T& pop();                               // Pop an object off the stack
    bool isEmpty() {return pHead == 0;}     // Empty test
};

// Copy constructor
template <typename T> Stack<T>::Stack(const Stack& aStack) {
  copy(aStack);
}

// Helper to copy a stack
template <typename T> void Stack<T>::copy(const Stack& aStack) {
  pHead = 0;
  if(aStack.pHead) {
    pHead = new Node(*aStack.pHead);        // Copy the top node of the original
    Node* pOldNode = aStack.pHead;      // Points to the top node of the original
    Node* pNewNode = pHead;                 // Points to the node in the new stack

    while(pOldNode = pOldNode->pNext) {     // If it is null, it is the last node
      pNewNode->pNext = new Node(*pOldNode);// Duplicate it
      pNewNode = pNewNode->pNext;           // Move to the node just created
    }
  }
}

// Assignment operator
template <typename T> Stack<T>& Stack<T>::operator=(const Stack& aStack) {
  if(this == &aStack)                      // If objects are identical
    return *this;                          // return the left object
  
  freeMemory();                            // Release memory for nodes in lhs
  copy(aStack);                            // Copy rhs to lhs

  return *this                             // Return the left object
}

// Helper to release memory for a stack
template <typename T> void Stack<T>::freeMemory() {
  Node* pTemp;
  while(pHead) {                           // While current pointer is not null
    pTemp = pHead->pNext;                  // Get the pointer to the next
    delete pHead;                          // Delete the current
    pHead = pTemp;                         // Make the next current
  }
}

// Destructor
template <typename T> Stack<T>::~Stack() {
  freeMemory();
}

// Push an object onto the stack
template <typename T> void Stack<T>::push(T& rItem) {
  Node* pNode = new Node(rItem);           // Create the new node
  pNode->pNext = pHead;                    // Point to the old top node
  pHead = pNode;                           // Make the new node the top
}

// Pop an object off the stack
template <typename T> T& Stack<T>::pop() {
  T* pItem = pHead->pItem;                 // Get pointer to the top node object
  if(!pItem)                               // If it is empty
    throw std::logic_error("Stack empty"); // Pop is not valid so throw exception

  Node* pTemp = pHead;                     // Save address of top node
  pHead = pHead->pNext;                    // Make next node the top
  delete pTemp;                            // Delete the previous top node
  return *pItem;                           // Return the top object
}
#endif
