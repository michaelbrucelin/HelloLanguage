package com.itheima.day13_oop_app3.d4_polymorphic_test;

/**
    目标：USB设备模拟
    1、定义USB接口：接入 拔出
    2、定义2个USB的实现类：鼠标、键盘。
    3、创建一个电脑对象，创建USB设备对象，安装启动。
 */
public class Test {
    public static void main(String[] args) {
        // a、创建电脑对象
        Computer c = new Computer();
        // b、创建USB设备对象
        USB u = new Mouse("罗技鼠标");
        c.installUSB(u);

        USB k = new KeyBoard("双飞燕键盘");
        c.installUSB(k);
    }

}
