#include <iostream>
#include <string>

class Company
{
public:
    Company(std::string name, std::string product);
    virtual void printInfo();

protected:
    std::string name;
    std::string product;
};

class TechCompany : public Company
{
public:
    TechCompany(std::string name, std::string product);
    virtual void printInfo();
};

Company::Company(std::string name, std::string product)
{
    this->name = name;
    this->product = product;
}

void Company::printInfo()
{
    std::cout << "这个公司的名字叫：" << name << "，正在生产" << product << std::endl;
}

TechCompany::TechCompany(std::string name, std::string product) : Company(name, product)
{
}

void TechCompany::printInfo()
{
    std::cout << name << "公司生产了大量的" << product << "这款产品" << std::endl;
}

int main(void)
{
    Company *company = new TechCompany("Apple", "IPhone");
    TechCompany *techCompany = (TechCompany *)company; //强制转换

    techCompany->printInfo();

    delete company;
    //delete techCompany; //注意，不能再次delete了，techCompany与company是同一块内存，不能重复释放内存

    company = NULL;
    techCompany = NULL;

    return (0);
}