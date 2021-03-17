#include <iostream>

//类的this指针，就是指向类自己的地址

class TestClass
{
public:
    TestClass();
};

TestClass::TestClass()
{
    std::cout << "构造器，this的值为：" << this << std::endl;
}

int main(void)
{
    TestClass testclass;
    std::cout << "testclass的地址为：" << &testclass << std::endl;

    return (0);
}