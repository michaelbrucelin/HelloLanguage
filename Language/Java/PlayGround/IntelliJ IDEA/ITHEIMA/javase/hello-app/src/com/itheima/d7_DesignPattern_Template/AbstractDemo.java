package com.itheima.d7_DesignPattern_Template;

public class AbstractDemo {
    public static void main(String[] args) {
        CurrentAccount acc = new CurrentAccount("ICBC-111", 100000);
        acc.handle("itheima", "123456");
    }
}