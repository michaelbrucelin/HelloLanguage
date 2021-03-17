#include <iostream>
#include <string>
#include <fstream>

//使用析构器，即C#中的析构函数

class StoreQuote
{
public:
    std::string quote, speaker;
    std::ofstream fileOutput;

    StoreQuote();  //构造器
    ~StoreQuote(); //析构器

    void inputQuote();
    void inputSpeaker();
    bool write();
};

//构造器
StoreQuote::StoreQuote()
{
    fileOutput.open("test.txt", std::ios::app);
}

//析构器
StoreQuote::~StoreQuote()
{
    fileOutput.close();
}

void StoreQuote::inputQuote()
{
    std::getline(std::cin, quote);
}

void StoreQuote::inputSpeaker()
{
    std::getline(std::cin, speaker);
}

bool StoreQuote::write()
{
    if (fileOutput.is_open())
    {
        fileOutput << quote << "|" << speaker << "\n";
        return true;
    }
    else
        return false;
}

int main(void)
{
    StoreQuote quote;

    std::cout << "请输入一句名言：\n";
    quote.inputQuote();
    std::cout << "请输入作者：\n";
    quote.inputSpeaker();

    if (quote.write())
        std::cout << "成功写入文件^_^\n";
    else
    {
        std::cout << "写入文件失败T_T\n";
        return 1;
    }

    return (0);
}