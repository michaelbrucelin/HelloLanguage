#include <iostream>
#include <string>

//类的继承过程中，子父类中的构造器/析构器的执行顺序

class BaseClass
{
public:
    BaseClass();
    ~BaseClass();

    void doSomething();
};

class SubClass : public BaseClass
{
public:
    SubClass();
    ~SubClass();
};

BaseClass::BaseClass()
{
    std::cout << "进入父类的构造器... ..." << std::endl;
}

BaseClass::~BaseClass()
{
    std::cout << "进入父类的析构器... ..." << std::endl;
}

void BaseClass::doSomething()
{
    std::cout << "正在执行方法... ..." << std::endl;
}

SubClass::SubClass()
{
    std::cout << "进入子类的构造器... ..." << std::endl;
}

SubClass::~SubClass()
{
    std::cout << "进入子类的析构器... ..." << std::endl;
}

int main(void)
{
    SubClass subclass;
    subclass.doSomething();

    std::cout << "done" << std::endl;

    return (0);
}