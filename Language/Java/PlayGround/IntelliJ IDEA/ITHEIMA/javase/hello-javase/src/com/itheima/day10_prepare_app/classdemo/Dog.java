package com.itheima.day10_prepare_app.classdemo;

public class Dog {
    private String name;
    private char sex;

    public Dog(){

    }

    public Dog(String name, char sex) {
        this.name = name;
        this.sex = sex;
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
}
