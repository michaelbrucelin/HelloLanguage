#include <fstream>
#include <iostream>

using namespace std;

int main(int argc, char *argv[])
{
    ifstream in;

    if (argc != 2)
    {
        fprintf(stderr, "输入形式：readfile file\n");
        exit(EXIT_FAILURE);
    }

    in.open(argv[1]);
    if (!in)
    {
        cerr << "无法打开文件" << argv[1] << "!\n"
             << endl;
        return (0);
    }

    char x;
    while (in >> x)
        cout << x;
    cout << endl;

    in.close();

    return (0);
}