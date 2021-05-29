#include <iostream>

//使用构造器，即C#中的构造函数

#define FULL_GAS 85

class Car
{
public:
    std::string color;
    std::string engine;
    unsigned int gas_tank;
    unsigned int wheel;

    Car(void); //构造器
    void setColor(std::string col);
    void setEngine(std::string eng);
    void setWheel(unsigned int whe);
    void fillTank(int liter);
    int running(void);
    void warning(void);
};

//构造器
Car::Car(void)
{
    color = "White";
    engine = "V8";
    wheel = 4;
    gas_tank = FULL_GAS;
}

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

    //因为有构造器，所以就不需要下面的赋值操作了
    //mycar.setColor("WHITE");
    //mycar.setEngine("V8");
    //mycar.setWheel(4);

    //mycar.gas_tank = FULL_GAS;

    while (!mycar.running())
        ;

    return (0);
}