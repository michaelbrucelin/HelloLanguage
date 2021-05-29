#include <iostream>
#include <string>

//类模板，类似于C#中的泛型类

template <class T>
class Stack
{
public:
    Stack(unsigned int size = 100);
    ~Stack();

    void push(T value);
    T pop();

private:
    unsigned int size;
    unsigned int sp; //数组下标
    T *data;
};

template <class T>
Stack<T>::Stack(unsigned int size)
{
    this->size = size;
    data = new T[size];
    sp = 0;
}

template <class T>
Stack<T>::~Stack()
{
    delete[] data;
}

template <class T>
void Stack<T>::push(T value)
{
    data[sp++] = value;
}

template <class T>
T Stack<T>::pop()
{
    return data[--sp];
}

int main(void)
{
    Stack<int> intStack(100);

    intStack.push(1);
    intStack.push(2);
    intStack.push(3);
    intStack.push(4);

    std::cout << intStack.pop() << std::endl;
    std::cout << intStack.pop() << std::endl;
    std::cout << intStack.pop() << std::endl;
    std::cout << intStack.pop() << std::endl;

    return (0);
}