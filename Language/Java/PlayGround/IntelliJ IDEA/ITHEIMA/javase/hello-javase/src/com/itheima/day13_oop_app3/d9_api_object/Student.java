package com.itheima.day13_oop_app3.d9_api_object;

import java.util.Objects;

public class Student { //extends Object{
    private String name;
    private char sex;
    private int age;

    public Student() {
    }

    public Student(String name, char sex, int age) {
        this.name = name;
        this.sex = sex;
        this.age = age;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public char getSex() {
        return sex;
    }

    public void setSex(char sex) {
        this.sex = sex;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    /**
     定制相等规则。
     两个对象的内容一样就认为是相等的
     s1.equals(s2)
     比较者：s1 == this
     被比较者： s2 ==> o
     */
    @Override
    public boolean equals(Object o) {
        // 1、判断是否是同一个对象比较，如果是返回true。
        if (this == o) return true;
        // 2、如果o是null返回false  如果o不是学生类型返回false  ...Student !=  ..Pig
        if (o == null || this.getClass() != o.getClass()) return false;
        // 3、说明o一定是学生类型而且不为null
        Student student = (Student) o;
        return sex == student.sex && age == student.age && Objects.equals(name, student.name);
    }


    /**
       自己重写equals，自己定制相等规则。
        两个对象的内容一样就认为是相等的
     s1.equals(s2)
     比较者：s1 == this
     被比较者： s2 ==> o
     */
 /*   @Override
    public boolean equals(Object o){
        // 1、判断o是不是学生类型
        if(o instanceof Student){
            Student s2 = (Student) o;
            // 2、判断2个对象的内容是否一样。
//            if(this.name.equals(s2.name) &&
//                 this.age == s2.age && this.sex == s2.sex){
//                return true;
//            }else {
//                return false;
//            }
            return this.name.equals(s2.name) && this.age == s2.age
                    && this.sex == s2.sex ;

        }else {
            // 学生只能和学生比较，否则结果一定是false
            return false;
        }
    }*/


    @Override
    public String toString() {
        return "Student{" +
                "name='" + name + '\'' +
                ", sex=" + sex +
                ", age=" + age +
                '}';
    }
}
