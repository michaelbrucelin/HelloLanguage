#include <iostream>
#include <string>

//副本构造器，就是C#中的深拷贝
//045中如果改为  MyClass obj1; MyClass obj2 = obj1; 的话，重载的运算符=就没有用了，因为这时obj2是定义加声明，此时会使用MyClass的默认的构造器，而默认的构造器就会逐位复制
//想要解决这个问题，就可以自己写一个构造器，而不是使用默认的构造器

class MyClass
{
public:
    MyClass(int *p);
    MyClass(const MyClass &rhs); //增加一个构造器，用于深复制
    ~MyClass();

    MyClass &operator=(const MyClass &rhs); //重载=运算符，实现深拷贝
    void print();

private:
    int *ptr;
};

MyClass::MyClass(int *ptr)
{
    std::cout << "进入主构造器" << std::endl;
    this->ptr = ptr;
    std::cout << "离开主构造器" << std::endl;
}

MyClass::MyClass(const MyClass &rhs)
{
    std::cout << "进入副本构造器" << std::endl;
    *this = rhs; //调用运算符重载
    std::cout << "离开副本构造器" << std::endl;
}

MyClass::~MyClass()
{
    std::cout << "进入析构器" << std::endl;
    delete ptr;
    std::cout << "离开析构器" << std::endl;
}

//重载=运算符，实现深拷贝
MyClass &MyClass::operator=(const MyClass &rhs)
{
    std::cout << "进入赋值语句重载" << std::endl;

    if (this != &rhs)
    {
        if (ptr != nullptr)
            delete ptr;

        ptr = new int;
        *ptr = *rhs.ptr;
    }
    else
    {
        std::cout << "赋值符号两边是同一个对象，不做处理！" << std::endl;
    }

    std::cout << "离开赋值语句重载" << std::endl;

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
    obj2 = obj1;
    obj1.print();
    obj2.print();

    std::cout << "================================================================" << std::endl;

    MyClass obj3(new int(3));
    MyClass obj4 = obj3;
    obj3.print();
    obj4.print();

    std::cout << "================================================================" << std::endl;

    MyClass obj5(new int(5));
    obj5 = obj5;
    obj5.print();

    return (0);
}