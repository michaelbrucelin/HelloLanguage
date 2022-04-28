package com.itheima.day07_oop_app.javabean;

public class Test {
    public static void main(String[] args) {
        User user = new User();
        user.setName("二狗");
        user.setHeight(163);
        user.setSalary(50000);
        user.setAddress("中国");
        user.setPhone("13141314520");
//        String name = user.getName();
//        System.out.println(name);
        System.out.println(user.getName());
        System.out.println(user.getHeight());
        System.out.println(user.getSalary());
        System.out.println(user.getAddress());
        System.out.println(user.getPhone());

        System.out.println("--------------------");
        User user1 = new User(176, "黑马吴彦祖", 30000, "黑马", "110");
        System.out.println(user1.getName());
        System.out.println(user1.getHeight());
        System.out.println(user1.getSalary());
        System.out.println(user1.getAddress());
        System.out.println(user1.getPhone());
    }
}
