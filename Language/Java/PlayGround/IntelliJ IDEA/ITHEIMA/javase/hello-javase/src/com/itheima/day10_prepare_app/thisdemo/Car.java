package com.itheima.day10_prepare_app.thisdemo;

public class Car {
    private String name;
    private double price;

    public Car(String name, double price){
        this.name = name;
        this.price = price;
    }

    public void go(String name){
        System.out.println(this);
        System.out.println(this.name + "正在和" + name +"比赛！");
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
}
