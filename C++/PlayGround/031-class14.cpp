#include <iostream>

//基类的析构器需要是虚方法，否则的话实现多态时，调用的都是基类的析构器，而没有调用子类的析构器，会造成内存泄漏
//如果基类的析构器是虚方法，那么继承下来的子类的析构器也一定是虚方法

class ClxBase
{
public:
    ClxBase()
    {
    }

    //~ClxBase() //如果没有定义为虚方法，下面使用delete释放内存的时候就没有正确的释放内存
    virtual ~ClxBase()
    {
        std::cout << "Output from the destructor of class ClxBase!" << std::endl;
    }

    virtual void doSomething()
    {
        std::cout << "Do something in class ClxBase!" << std::endl;
    }
};

class ClxDerived : public ClxBase
{
public:
    ClxDerived()
    {
    }

    ~ClxDerived()
    {
        std::cout << "Output from the destructor of class ClxDerived!" << std::endl;
    }

    void doSomething()
    {
        std::cout << "Do something in class ClxDerived!" << std::endl;
    }
};

int main(void)
{
    ClxBase *pTest = new ClxDerived;
    pTest->doSomething();

    delete pTest;

    return (0);
}