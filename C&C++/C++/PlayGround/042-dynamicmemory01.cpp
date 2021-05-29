#include <iostream>
#include <string>

class Company
{
public:
    Company(std::string name);
    virtual void printInfo();

protected:
    std::string name;
};

class TechCompany : public Company
{
public:
    TechCompany(std::string name, std::string product);
    virtual void printInfo();

private:
    std::string product;
};

Company::Company(std::string name)
{
    this->name = name;
}

void Company::printInfo()
{
    std::cout << "这个公司的名字叫：" << name << "。" << std::endl;
}

TechCompany::TechCompany(std::string name, std::string product) : Company(name)
{
    this->product = product;
}

void TechCompany::printInfo()
{
    std::cout << name << "公司大量生产了" << product << "这款产品！" << std::endl;
}

int main(void)
{
    Company *company = new Company("Apple");
    company->printInfo();
    delete company;
    company = NULL;

    company = new TechCompany("Apple", "IPhone");
    company->printInfo();
    delete company;
    company = NULL;

    return (0);
}