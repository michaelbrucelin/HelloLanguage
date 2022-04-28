package com.itheima.day12_oop_app2.d9_abstract_template.after;

public class Test {
    public static void main(String[] args) {
        CurrentAccount acc = new CurrentAccount("ICBC-111", 100000);
        acc.handle("itheima", "123456");
    }
}
