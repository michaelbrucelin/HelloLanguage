package com.itheima.d03_static;

public class StaticFieldDemo {
    public static void main(String[] args) {
        // 1. 静态成员变量可以直接使用类来访问
        System.out.println(User.onlineCount);

        // 2. 静态成员变量也可以使用对象来访问，但是不推荐
        User u1 = new User();
        System.out.println(u1.onlineCount);
        User u2 = new User();
        u2.onlineCount++;
        System.out.println(u1.onlineCount);  // 静态成员变量在内存中只有一份，所以每次访问都是一样的
        System.out.println(User.onlineCount);
    }
}
