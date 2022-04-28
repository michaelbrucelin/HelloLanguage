package com.itheima.day10_prepare_app.thisdemo;

public class Test {
    public static void main(String[] args) {
        Car c1 = new Car("法拉利", 5000000);
        System.out.println(c1.getName());
        System.out.println(c1.getPrice());

        c1.go("保时捷");
        System.out.println(c1);
    }
}
