#include <iostream>
#include <string>

//047中直接使用(targetType)sourceType强制转换，如果sourceType和targetType无法强制转换，程序就会崩溃
//这里使用C++提供的函数进行强制转换

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
    Company *company = new Company("Apple", "IPhone");
    TechCompany *techCompany = dynamic_cast<TechCompany *>(company); //强制转换

    if (techCompany != NULL)
        std::cout << "成功！" << std::endl;
    else
        std::cout << "失败！" << std::endl;

    techCompany->printInfo();

    delete company;
    //delete techCompany; //注意，不能再次delete了，techCompany与company是同一块内存，不能重复释放内存

    company = NULL;
    techCompany = NULL;

    return (0);
}