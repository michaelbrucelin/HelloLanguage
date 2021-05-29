#include <iostream>
#include <string>

//友元类，可以让另一个类访问当前类中受保护的成员
//实际上，对友元函数的需求比较少，通常是在当函数（类）需要完全访问两个不同对象的内部时，才需要将该函数声明为这两个类的友元函数（类）

class Lovers
{
public:
    Lovers(std::string name);
    void kiss(Lovers *lover);
    void ask(Lovers *lover, std::string something);

protected:
    std::string name;

    friend class Others; //设置Others类为Lovers类的友元类，这样Others就可以访问Lovers中受保护的成员
};

class BoyFriend : public Lovers
{
public:
    BoyFriend(std::string name);
};

class GirlFriend : public Lovers
{
public:
    GirlFriend(std::string name);
};

class Others
{
public:
    Others(std::string name);
    void kiss(Lovers *lover);

protected:
    std::string name;
};

Lovers::Lovers(std::string name)
{
    this->name = name;
}

void Lovers::kiss(Lovers *lover)
{
    std::cout << name << "亲了我们家的" << lover->name << std::endl;
}

void Lovers::ask(Lovers *lover, std::string something)
{
    std::cout << "宝贝儿" << lover->name << "帮我" << something << std::endl;
}

BoyFriend::BoyFriend(std::string name) : Lovers(name)
{
}

GirlFriend::GirlFriend(std::string name) : Lovers(name)
{
}

Others::Others(std::string name)
{
    this->name = name;
}

void Others::kiss(Lovers *lover)
{
    std::cout << name << "亲了一下" << lover->name << std::endl;
}

int main(void)
{
    BoyFriend bf("A君");
    GirlFriend gf("B妞");

    Others other("路人甲");

    gf.kiss(&bf);
    gf.ask(&bf, "洗衣服啦");

    std::cout << std::endl
              << "当当当当！传说中的路人甲登场了... ..." << std::endl;
    other.kiss(&gf);

    return (0);
}