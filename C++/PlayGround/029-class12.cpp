#include <iostream>
#include <string>

//使用new和delete，就是C中的malloc与free的封装
//使用虚方法，实现多态，所以C++中的析构器都是虚方法（不是默认实现，需要手动添加virtual），具体见031-class14.cpp

class Animal
{
public:
    std::string mouth;
    std::string name;

    Animal(std::string name)
    {
        this->name = name;
    }

    void eat() //不使用virtual定义为虚方法，下面没有办法实现多态
    {
        std::cout << "eatting... ..." << std::endl;
    }

    virtual void sleep() //使用virtual定义为虚方法，实现多态
    {
        std::cout << "sleeping... ..." << std::endl;
    }
};

class Pig : public Animal
{
public:
    Pig(std::string name) : Animal(name)
    {
    }

    void eat() //覆盖父类的eat()方法
    {
        std::cout << "小猪有自己的eat()方法... ..." << std::endl;
    }

    void sleep()
    {
        std::cout << "小猪有自己的sleep()方法... ..." << std::endl;
    }
};

class Turtle : public Animal
{
public:
    Turtle(std::string name) : Animal(name)
    {
    }

    void eat() //覆盖父类的eat()方法
    {
        std::cout << "乌龟有自己的eat()方法... ..." << std::endl;
    }

    void sleep()
    {
        std::cout << "乌龟有自己的sleep()方法... ..." << std::endl;
    }
};

int main(void)
{
    //使用new声明类，并使用父类声明子类成员，来实现多态
    Animal *pig = new Pig("小猪猪");
    Animal *turtle = new Turtle("小乌龟");

    //eat没有调用子类重写的方法，仍然是父类的方法，没有实现多态
    pig->eat();
    turtle->eat();
    //sleep调用的子类重写的方法，实现了多态
    pig->sleep();
    turtle->sleep();

    //使用delete释放内存
    delete pig;
    delete turtle;

    return (0);
}