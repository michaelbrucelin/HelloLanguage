#include <iostream>
#include <string>

//类的多继承，多继承可能会引发很多问题，例如038中的继承了两个父类的那么属性
//这个问题可通过虚继承来解决，通过虚继承某个基类，就是告诉编译器，从当前这个类再派生出来的子类只能拥有那个基类的一个实例
//即从Teacher类和Student类再派生出来的子类，只能拥有一份Person类的属性

class Person
{
public:
    Person(std::string name);

    void introduce();

protected:
    std::string name;
};

class Teacher : virtual public Person //使用虚继承，这样Teacher类的派生类就只能拥有一份Person类的属性
{
public:
    Teacher(std::string name, std::string classes);

    void teach();
    void introduce();

protected:
    std::string classes;
};

class Student : virtual public Person //使用虚继承，这样Student类的派生类就只能拥有一份Person类的属性
{
public:
    Student(std::string name, std::string classes);

    void attendClass();
    void introduce();

protected:
    std::string classes;
};

class TeachingStudent : public Student, public Teacher
{
public:
    TeachingStudent(std::string name, std::string classTeaching, std::string classAttending);

    void introduce();
};

Person::Person(std::string name)
{
    this->name = name;
}

void Person::introduce()
{
    std::cout << "大家好，我是" << name << "。" << std::endl
              << std::endl;
}

Teacher::Teacher(std::string name, std::string classes) : Person(name)
{
    this->classes = classes;
}

void Teacher::teach()
{
    std::cout << name << "教" << classes << "。" << std::endl
              << std::endl;
}

void Teacher::introduce()
{
    std::cout << "大家好，我是" << name << "，我教" << classes << "。" << std::endl
              << std::endl;
}

Student::Student(std::string name, std::string classes) : Person(name)
{
    this->classes = classes;
}

void Student::attendClass()
{
    std::cout << name << "加入" << classes << "学习。" << std::endl
              << std::endl;
}

void Student::introduce()
{
    std::cout << "大家好，我是" << name << "我在" << classes << "学习。" << std::endl
              << std::endl;
}

TeachingStudent::TeachingStudent(std::string name,
                                 std::string classTeaching,
                                 std::string classAttending)
    : Teacher(name, classTeaching), Student(name, classAttending), Person(name)
{
}

void TeachingStudent::introduce()
{
    std::cout << "大家好，我是" << Student::name << "，我教" << Teacher::classes << "，";
    std::cout << "同时我在" << Student::classes << "学习。" << std::endl
              << std::endl;
}

int main(void)
{
    Teacher teacher("老师甲", "C++入门班");
    Student student("学生A", "C++入门班");
    TeachingStudent teachingstudent("助教A", "C++入门班", "C++进阶班");

    teacher.introduce();
    teacher.teach();
    student.introduce();
    student.attendClass();
    teachingstudent.introduce();
    teachingstudent.teach();
    teachingstudent.attendClass();

    return (0);
}