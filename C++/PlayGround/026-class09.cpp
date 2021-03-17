#include <iostream>
#include <string>

//类的静态成员，类的静态成员是该类的所有实例对象所共享的资源，但是其他类不可访问，有别于全局的静态变量

class Pet
{
public:
    Pet(std::string name);
    ~Pet();

    static int getCount(); //计数器，返回私有静态属性，类似于C#的只读静态属性

protected:
    std::string name;

private:
    static int count;
};

class Cat : public Pet
{
public:
    Cat(std::string name);
};

class Mouse : public Pet
{
public:
    Mouse(std::string name);
};

int Pet::count = 0; //编译器为计数器的值开辟内存空间并赋初值

Pet::Pet(std::string name)
{
    this->name = name;
    count++;

    std::cout << "一直宠物出生了，名字叫做：" << name << std::endl;
}

Pet::~Pet()
{
    count--;
    std::cout << "宠物" << name << "挂掉了" << std::endl;
}

int Pet::getCount()
{
    return count;
}

Cat::Cat(std::string name) : Pet(name)
{
}

Mouse::Mouse(std::string name) : Pet(name)
{
}

int main(void)
{
    Cat cat("Tom");
    Mouse mouse("Jerry");

    std::cout << "已经诞生了" << Pet::getCount() << "只宠物" << std::endl
              << std::endl;

    {
        Cat cat2("Tom2");
        Mouse mouse2("Jerry2");

        std::cout << "现在呢，已经诞生了" << Pet::getCount() << "只宠物" << std::endl
                  << std::endl;
    } //这个大括号是由作用的，是一个独立的作用域，出了该作用域后，内部栈中的资源被释放

    std::cout << "现在还剩下" << Pet::getCount() << "只宠物" << std::endl;

    return (0);
}