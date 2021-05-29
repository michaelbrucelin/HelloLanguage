#include <iostream>
#include <string>

//副本构造器，就是C#中的深拷贝
//当拷贝一个对象时，默认是逐位复制（bitwise copy）
//这样一旦对象中含有一个指针，那么拷贝出来的那个对象对应的成员与源对象指向的是同一块内存空间，即C#中的浅拷贝，这样会有问题，比方说手动释放内存的时候
//这个示例模拟用重载=运算符来实现“C#深拷贝”

class MyClass
{
public:
    MyClass(int *p);
    ~MyClass();

    MyClass &operator=(const MyClass &rhs); //重载=运算符，实现深拷贝
    void print();

private:
    int *ptr;
};

MyClass::MyClass(int *ptr)
{
    this->ptr = ptr;
}

MyClass::~MyClass()
{
    delete ptr;
}

//重载=运算符，实现深拷贝
MyClass &MyClass::operator=(const MyClass &rhs)
{
    if (this != &rhs)
    {
        delete ptr;

        ptr = new int;
        *ptr = *rhs.ptr;
    }
    else
    {
        std::cout << "赋值符号两边是同一个对象，不做处理！" << std::endl;
    }

    return *this;
}

void MyClass::print()
{
    std::cout << *ptr << std::endl;
}

int main(void)
{
    MyClass obj1(new int(1));
    MyClass obj2(new int(2));

    obj1.print();
    obj2.print();

    obj2 = obj1;

    obj1.print();
    obj2.print();

    return (0);
}