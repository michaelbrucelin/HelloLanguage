#include <iostream>
#include <string>

//类的多继承，多继承可能会引发很多问题，所以像Java/C#这些面对对象的语言都不允许类的多继承

class Person
{
public:
    Person(std::string name);

    void introduce();

protected:
    std::string name;
};

class Teacher : public Person
{
public:
    Teacher(std::string name, std::string classes);

    void teach();
    void introduce();

protected:
    std::string classes;
};

class Student : public Person
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
    : Teacher(name, classTeaching), Student(name, classAttending)
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