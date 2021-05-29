#include <iostream>
#include <string>

//类的继承

class Animal
{
public:
    std::string mouth;

    void eat();
    void sleep();
    void drool();
};

class Pig : public Animal
{
public:
    void climb();
};

class Turtle : public Animal
{
public:
    void swim();
};

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

void Pig::climb()
{
    std::cout << "climbing... ..." << std::endl;
}

void Turtle::swim()
{
    std::cout << "swimming... ..." << std::endl;
}

int main(void)
{
    Pig pig;
    Turtle turtle;

    pig.eat();
    pig.climb();
    turtle.eat();
    turtle.swim();

    return (0);
}