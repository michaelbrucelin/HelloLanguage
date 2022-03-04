// Exercise 18.3 LinkedListT.h

#ifndef LINKEDLISTT_H
#define LINKEDLISTT_H

template<typename T> class LinkedList {
  public:
    LinkedList(): pHead(0), pTail(0), pLast(0){}               // Constructor
    LinkedList(const LinkedList& list);                        // Copy constructor
    ~LinkedList();                                             // Destructor
    LinkedList& operator=(const LinkedList& list);             // Assignment operator
    void addHead(T* pObj);                                     // Add an object to the head
    void addTail(T* pObj);                                     // Add an object to the tail
    T* getHead();                                              // Get the object at the head
    T* getTail();                                              // Get the object at the head
    T* getNext();                                              // Get the next object
    T* getPrevious();                                          // Get the previous object
    
  private:
    // Node class definition
    class Node {
      public:
        int index;                       // Index of element
        T* pObject;                      // Reference to object
        Node* pNext;                     // Pointer to next node
        Node* pPrevious;                 // Pointer to previous node

        Node(T* pObj):
                  pObject(new T(*pObj)), pNext(0), pPrevious(0){}   // Constructor
        Node(const Node& node): 
                  index(node.index), pObject(new T(*node.pObject)), pNext(0), pPrevious(0){} 
                                         // Copy constructor 
        ~Node(){ delete pObject; }       // Destructor
    };

    Node* pHead;                         // Pointer to first element node
    Node* pTail;                         // Pointer to last element node
    Node* pLast;                         // Pointer to last node accessed
};


// Copy constructor template
template<typename T> LinkedList<T>::LinkedList(const LinkedList& list) {
  pLast = 0;                                       // New list not accessed yet
  if(list.pHead) {                                  // If there is a first element
    pTail = pHead = new Node(*list.pHead);         // Duplicate it

    Node* pTemp = 0;
    Node* pCurrent = list.pHead;
    while(pCurrent = pCurrent->pNext) {            // Duplicate any further nodes
      pTemp = pTail;                               // Save the address of the last
      pTail = new Node(*pCurrent);                 // Make the new one the last
      pTemp->pNext = pTail;                        // Set the next pointer of old last
      pTail->pPrevious = pTemp;                    // Set previous pointer of new last 
    }
  } else
    pTail = pHead = 0;
}

  
// Destructor template
template<typename T> LinkedList<T>::~LinkedList() {
  Node* pCurrent = pHead;
  Node* pTemp = 0;
  while(pCurrent) {                                // If there is a node
    pTemp = pCurrent->pNext;                       // Save the address of the next
    delete pCurrent;                               // Delete the current
    pCurrent = pTemp;                              // Make the next current
  }
}

// Assignment operator template
template<typename T> LinkedList<T>& LinkedList<T>::operator=(const LinkedList& list) {
   if(this == &list)             // Check for rhs same as lhs
    return *this;
  pLast = 0;
  Node* pCurrent = 0;
  if(list.pHead) {
    pTail = pHead = new Node(*list.pHead);
    Node* pTemp = 0;
    pCurrent = list.pHead;
    while(pCurrent = pCurrent->pNext) {
      pTemp = pTail;
      pTail = new Node(*pCurrent);
      pTemp->pNext = pTail;
      pTail->pPrevious = pTemp;
      pTemp = pTail;
    }
  } else
    pTail = pHead = 0;
  return *this;
}

// Template function member to add an object to the head of the list
template<typename T> void LinkedList<T>::addHead(T* pObj) {
  if(pHead) {
    pHead->pPrevious = new Node(pObj);
    pHead->pPrevious->pNext = pHead;
    pHead = pHead->pPrevious;
  } else
    pHead = pTail = new Node(pObj);
  pLast = pHead;

}

// Template function member to add an object to the tail of the list
template<typename T> void LinkedList<T>::addTail(T* pObj) {
  if(pTail) {
    pTail->pNext = new Node(pObj);
    pTail->pNext->pPrevious = pTail;
    pTail = pTail->pNext;
  } else
    pHead = pTail = new Node(pObj);
  pLast = pTail;
}

// Template function member to get the object at the head of the list
template<typename T> T* LinkedList<T>::getHead() {
  pLast = pHead;
  if(pHead)
    return pHead->pObject;
  else
    return 0;
}

// Template function member to get the object at the tail of the list
template<typename T> T* LinkedList<T>::getTail() {
  pLast = pTail;
  if(pTail)
    return pTail->pObject;
  else
    return 0;
}

// Template function member to get the next object
template<typename T> T* LinkedList<T>::getNext() {
  if(pLast)
    if(pLast = pLast->pNext)
      return pLast->pObject;
  return 0;
}

// Template function member to get the previous object
template<typename T> T* LinkedList<T>::getPrevious() {
  if(pLast)
    if(pLast = pLast->pPrevious)
      return pLast->pObject;
  return 0;
}

#endif //LINKEDLISTT_H