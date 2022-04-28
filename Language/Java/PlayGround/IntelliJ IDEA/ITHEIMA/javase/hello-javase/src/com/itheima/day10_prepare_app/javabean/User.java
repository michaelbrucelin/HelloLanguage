package com.itheima.day10_prepare_app.javabean;

public class User {
    private String name;
    private double height;
    private double salary;
    private String introduce;

    public User() {
    }

    public User(String name, double height, double salary, String introduce) {
        this.name = name;
        this.height = height;
        this.salary = salary;
        this.introduce = introduce;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    public String getIntroduce() {
        return introduce;
    }

    public void setIntroduce(String introduce) {
        this.introduce = introduce;
    }
}
