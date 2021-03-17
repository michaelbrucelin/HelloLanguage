#include <iostream>
#include <string>

//将类的声明写在类的内部，而不是传统的在外部写的方式

template <class T>
class Stack
{
public:
    Stack(unsigned int size = 100)
    {
        this->size = size;
        data = new T[size];
        sp = 0;
    }

    ~Stack()
    {
        delete[] data;
    }

    void push(T value)
    {
        data[sp++] = value;
    }

    T pop()
    {
        return data[--sp];
    }

private:
    unsigned int size;
    unsigned int sp; //数组下标
    T *data;
};

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