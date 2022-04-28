package com.itheima.day07_oop_app.memory;

public class Test {
    public static void main(String[] args) {
        // 目标：掌握2个变量指向同一个对象的形式
        Student s1 = new Student();
        s1.name = "小明";
        s1.sex = '男';
        s1.hobby = "睡觉、游戏、听课";
        s1.study();

        // 关键：把s1赋值给学生类型的变量s2
        Student s2 =  s1;
        System.out.println(s1);
        System.out.println(s2);

        s2.hobby = "爱提问";

        System.out.println(s2.name);
        System.out.println(s2.sex);
        System.out.println(s1.hobby);
        s2.study();

        s1 = null;
        s2 = null;
        System.out.println(s1.name);
    }
}
