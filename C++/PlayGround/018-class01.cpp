#include <iostream>

#define FULL_GAS 85

// 这里Car的定义和Car中方法的实现分开写，这是C++的推荐方式，更规范的是将Car的定义单独放到头文件中，方法的实现放在代码文件中
// 如果愿意，C++也可以像C#那样，将Car中方法的实现直接写在Car的定义中
class Car
{
public:
    std::string color;
    std::string engine;
    unsigned int gas_tank;
    unsigned int wheel;

    void setColor(std::string col);
    void setEngine(std::string eng);
    void setWheel(unsigned int whe);
    void fillTank(int liter);
    int running(void);
    void warning(void);
};

void Car::setColor(std::string col)
{
    color = col;
}

void Car::setEngine(std::string eng)
{
    engine = eng;
}

void Car::setWheel(unsigned int whe)
{
    wheel = whe;
}

void Car::fillTank(int liter)
{
    gas_tank += liter;
}

int Car::running(void)
{
    char i;

    std::cout << "running... ... running ... ... running ... ...\n";
    gas_tank--;
    std::cout << "当前还剩" << 100 * gas_tank / FULL_GAS << "%"
              << "油量。\n";

    if (gas_tank < 10)
    {
        warning();
        std::cout << "请问是否需要加满油再继续行驶？（Y/N）\n";
        std::cin >> i;
        if ('Y' == i || 'y' == i)
            fillTank(FULL_GAS);

        if (0 == gas_tank)
        {
            std::cout << "抛锚中... ...\n";
            return 1;
        }
    }

    return 0;
}

void Car::warning(void)
{
    std::cout << "WARNING!!!"
              << "还剩" << 100 * gas_tank / FULL_GAS << "%"
              << "油量";
}

int main(void)
{
    Car mycar;

    mycar.setColor("WHITE");
    mycar.setEngine("V8");
    mycar.setWheel(4);

    mycar.gas_tank = FULL_GAS;

    while (!mycar.running())
        ;

    return (0);
}