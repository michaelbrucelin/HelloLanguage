package com.itheima.day07_oop_app.javabean;

public class User {
    private double height;
    private String name;
    private double salary;
    private String address;
    private String phone;

    public User() {
    }

    public User(double height, String name, double salary, String address, String phone) {
        this.height = height;
        this.name = name;
        this.salary = salary;
        this.address = address;
        this.phone = phone;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getSalary() {
        return salary;
    }

    public void setSalary(double salary) {
        this.salary = salary;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }
}
