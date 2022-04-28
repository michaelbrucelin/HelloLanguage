package com.itheima.day11_oop_app1.d13_extends_constructor2;

public class Student extends People{
    private String className;

    public Student(){
    }

    public Student(String name, int age, String className) {
        super(name, age);
        this.className = className;
    }

    public String getClassName() {
        return className;
    }

    public void setClassName(String className) {
        this.className = className;
    }
}
