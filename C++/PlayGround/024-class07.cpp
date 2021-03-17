#include <iostream>
#include <string>

//继承中方法的覆盖

class Animal
{
public:
    std::string mouth;
    std::string name;

    Animal(std::string name);
    void eat();
    void sleep();
    void drool();
};

class Pig : public Animal
{
public:
    Pig(std::string name);

    void eat(); //覆盖父类的方法，下面会重新实现
    void climb();
};

class Turtle : public Animal
{
public:
    Turtle(std::string name);

    void eat(); //覆盖父类的方法，下面会重新实现
    void swim();
};

Animal::Animal(std::string name)
{
    this->name = name;
}

void Animal::eat()
{
    std::cout << "eatting... ..." << std::endl;
}

void Animal::sleep()
{
    std::cout << "sleeping... ..." << std::endl;
}

void Animal::drool()
{
    std::cout << "drooling... ..." << std::endl;
}

//构造器的继承
Pig::Pig(std::string name) : Animal(name)
{
}

//覆盖父类的eat()方法
void Pig::eat()
{
    Animal::eat(); //可以保留父类的实现
    std::cout << "小猪有自己的eat()方法... ..." << std::endl;
}

void Pig::climb()
{
    std::cout << "climbing... ..." << std::endl;
}

//构造器的继承
Turtle::Turtle(std::string name) : Animal(name)
{
}

//覆盖父类的eat()方法
void Turtle::eat()
{
    Animal::eat(); //可以保留父类的实现
    std::cout << "乌龟有自己的eat()方法... ..." << std::endl;
}

void Turtle::swim()
{
    std::cout << "swimming... ..." << std::endl;
}

int main(void)
{
    Pig pig("小猪猪");
    Turtle turtle("小乌龟");

    std::cout << "这只乌龟的名字是：" << pig.name << std::endl;
    std::cout << "这只小猪的名字是：" << turtle.name << std::endl;

    pig.eat();
    pig.climb();
    turtle.eat();
    turtle.swim();

    return (0);
}