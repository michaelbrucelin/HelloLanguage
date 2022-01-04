#include <fstream>
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
    ofstream out;

    if (argc != 2)
    {
        fprintf(stderr, "输入形式：writefile file\n");
        exit(EXIT_FAILURE);
    }

    out.open(argv[1]);
    if (!out)
    {
        cerr << "无法打开文件" << argv[1] << "!\n"
             << endl;
        return (0);
    }

    for (size_t i = 0; i < 10; i++)
        out << i;
    cout << endl;

    out.close();

    return (0);
}