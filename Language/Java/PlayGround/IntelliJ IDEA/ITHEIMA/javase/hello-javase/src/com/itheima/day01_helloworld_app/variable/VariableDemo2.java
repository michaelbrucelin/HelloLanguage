package com.itheima.day01_helloworld_app.variable;

public class VariableDemo2 {
    public static void main(String[] args) {
        // 目标：识别定义变量常见的问题，并注意
        // 1、什么类型的变量一定是存放什么类型的数据
        int age = 21;

        // 2、同一个范围内不能定义重名的变量
        // int age = 25;
        age = 25; // 这里是赋值不是定义，所以没毛病！！

        // 3、变量定义的时候可以不给初始化值，但是使用的时候必须有初始化值。
        double money ;
        money = 10000;
        System.out.println(money);

        {
            int number = 90;
            System.out.println(number);
        }
        // System.out.println(number); 报错！
        System.out.println(age);
    }
}
