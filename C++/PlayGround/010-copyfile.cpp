#include <fstream>
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
    ifstream in;
    ofstream out;

    if (argc != 3)
    {
        fprintf(stderr, "输入形式：readfile srcfile dstfile\n");
        exit(EXIT_FAILURE);
    }

    in.open(argv[1]);
    if (!in)
    {
        cerr << "无法打开源文件" << argv[1] << "!\n"
             << endl;
        return (0);
    }

    out.open(argv[2]);
    if (!out)
    {
        cerr << "无法打开目标文件" << argv[2] << "!\n"
             << endl;
        return (0);
    }

    char x;
    while (in >> x)
        out << x;
    out << endl;

    in.close();
    out.close();

    cout << "CPP成功复制1个文件！\n"
         << endl;

    return (0);
}