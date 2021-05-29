#include <iostream>

//类的this指针

class Point
{
private:
    int x, y;

public:
    Point(int x, int y)
    {
        this->x = x;
        this->y = y;
    }

    void MoveTo(int x, int y)
    {
        this->x = x;
        this->y = y;
    }

    void Offset(int a, int b)
    {
        this->x += a;
        this->y += b;
    }

    void print()
    {
        std::cout << "x = " << x << ", y = " << y << std::endl;
    }
};

int main(void)
{
    Point point(10, 10);
    point.MoveTo(16, 16);
    point.print();

    return (0);
}

/*
当对象point调用MoveTo(16, 16)方法时，即将point对象的地址传递给了this指针；

MobeTo()方法的原型事实上应该是 void MoveTo(Point *this, int x, int y);
第一个参数是指向该对象的指针，我们在定义类的成员时没有看见时因为这个参数时类中隐含的；

这样point的地址传递给了this，所以在MoveTo()方法中便可以写成 this->x = x; this -> y = y;
即可以知道point调用了该方法后，也就是point对象的数据成员被调用并更新的值；
*/